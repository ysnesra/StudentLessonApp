using AutoMapper;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Lesson;
using StudentLessonApp.Application.DTOs.StudentLesson;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Migrations;
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
        private readonly IUnitOfWork _unitOfWork;

        public StudentLessonService(IStudentLessonReadRepository studentLessonReadRepository, IStudentLessonWriteRepository studentLessonWriteRepository, IStudentService studentService, ILessonService lessonService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _studentLessonReadRepository = studentLessonReadRepository;
            _studentLessonWriteRepository = studentLessonWriteRepository;
            _studentService = studentService;
            _lessonService = lessonService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        public async Task<SelectLessonByStudentDto> SelectLessonByStudentAsync(Guid studentId, List<Guid> lessonIds)
        {
            SelectLessonByStudentDto studentLessonByStudentDto = new SelectLessonByStudentDto();
            List<StudentLessonsDto> studentLessonDtos = new List<StudentLessonsDto>();

            foreach (var lessonId in lessonIds)
            {
                var existlesson = await _lessonService.GetByIdAsync(lessonId);

                if (existlesson is null)
                {
                    studentLessonByStudentDto.Success = false;
                    studentLessonByStudentDto.Message = $"Lesson with ID {lessonId} does not exist in the system.";
                    return studentLessonByStudentDto; 
                }

               // var isLessonStudent = await _studentLessonReadRepository.GetFirstAsync(x => x.StudentId == studentId && x.LessonId == lessonId);

                //if (isLessonStudent is not null)
                //{
                //    studentLessonByStudentDto.Success = false;
                //    studentLessonByStudentDto.Message = $"Student has already chosen Lesson with ID {lessonId}.";
                //    return studentLessonByStudentDto; 
                //}

                StudentLesson studentLesson = new StudentLesson()
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentId,
                    LessonId = lessonId
                };
                

                await _studentLessonWriteRepository.AddAsync(studentLesson);

                var mappedStudentLesson = new StudentLessonsDto
                {
                    Id = studentLesson.Id,
                    StudentId = studentLesson.StudentId,
                    LessonId = studentLesson.LessonId
                };

                studentLessonDtos.Add(mappedStudentLesson);

            }
       

            studentLessonByStudentDto.Success = true;
            studentLessonByStudentDto.Message = "Lessons selected successfully.";
            studentLessonByStudentDto.StudentLessonsDto = studentLessonDtos;
            return studentLessonByStudentDto;
        }
    }
}
