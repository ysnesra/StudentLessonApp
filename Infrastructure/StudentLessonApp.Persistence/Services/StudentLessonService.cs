using AutoMapper;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Lesson;
using StudentLessonApp.Application.DTOs.StudentLesson;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Repositories;

namespace StudentLessonApp.Persistence.Services
{
    public class StudentLessonService : IStudentLessonService
    {
        private readonly IStudentLessonReadRepository _studentLessonReadRepository;
        private readonly IStudentLessonWriteRepository _studentLessonWriteRepository;
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public StudentLessonService(IStudentLessonReadRepository studentLessonReadRepository, IStudentLessonWriteRepository studentLessonWriteRepository, IStudentService studentService, ILessonService lessonService, IMapper mapper)
        {
            _studentLessonReadRepository = studentLessonReadRepository;
            _studentLessonWriteRepository = studentLessonWriteRepository;
            _studentService = studentService;
            _lessonService = lessonService;
            _mapper = mapper;
        }

        //public async Task SelectLessonByStudentAsync(Guid studentId, Guid lessonId)
        //{
        //    SelectLessonByStudentDto studentLessonByStudentDto = new SelectLessonByStudentDto();
        //    var existlesson = await _lessonService.GetByIdAsync(lessonId);
        //    if (existlesson is null)
        //    {
        //        studentLessonByStudentDto.Success = false;
        //        studentLessonByStudentDto.Message = "This lesson does not exist in the system.";            
        //    }
              
        //    var isLessonStudent = await _studentLessonReadRepository.GetFirstAsync(x => x.StudentId == studentId && x.LessonId == lessonId);
        //    if (isLessonStudent is not null)
        //    {
        //        studentLessonByStudentDto.Success = false;
        //        studentLessonByStudentDto.Message = "A student can choose to a Lesson only once.";              
        //    }

        //    StudentLesson studentLesson = new StudentLesson()
        //    {
        //        StudentId = studentId,
        //        LessonId = lessonId
        //    };
        //    var studentLessonDb= await _studentLessonWriteRepository.AddAsync(studentLesson);        
        //}

        public async Task<SelectLessonByStudentDto> SelectLessonByStudentAsync(Guid studentId, ICollection<Guid> lessonIds)
        {
            SelectLessonByStudentDto studentLessonByStudentDto = new SelectLessonByStudentDto();

            foreach (var lessonId in lessonIds)
            {
                var existlesson = await _lessonService.GetByIdAsync(lessonId);

                if (existlesson is null)
                {
                    studentLessonByStudentDto.Success = false;
                    studentLessonByStudentDto.Message = $"Lesson with ID {lessonId} does not exist in the system.";
                    return studentLessonByStudentDto; 
                }

                var isLessonStudent = await _studentLessonReadRepository.GetFirstAsync(x => x.StudentId == studentId && x.LessonId == lessonId);

                if (isLessonStudent is not null)
                {
                    studentLessonByStudentDto.Success = false;
                    studentLessonByStudentDto.Message = $"Student has already chosen Lesson with ID {lessonId}.";
                    return studentLessonByStudentDto; 
                }

                StudentLesson studentLesson = new StudentLesson()
                {
                    StudentId = studentId,
                    LessonId = lessonId
                };

                await _studentLessonWriteRepository.AddAsync(studentLesson);
            }

            studentLessonByStudentDto.Success = true;
            studentLessonByStudentDto.Message = "Lessons selected successfully.";
            return studentLessonByStudentDto;
        }
    }
}
