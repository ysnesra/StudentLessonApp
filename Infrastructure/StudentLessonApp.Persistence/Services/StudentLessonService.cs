using AutoMapper;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.StudentLesson;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;

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

        public async Task SelectLessonByStudentAsync(Guid studentId, Guid lessonId)
        {
            SelectLessonByStudentDto studentLessonByStudentDto = new SelectLessonByStudentDto();
            var existlesson = await _lessonService.GetByIdAsync(lessonId);
            if (existlesson is null)
            {
                studentLessonByStudentDto.Success = false;
                studentLessonByStudentDto.Message = "This lesson does not exist in the system.";            
            }
              
            var isLessonStudent = await _studentLessonReadRepository.GetFirstAsync(x => x.StudentId == studentId && x.LessonId == lessonId);
            if (isLessonStudent is not null)
            {
                studentLessonByStudentDto.Success = false;
                studentLessonByStudentDto.Message = "A student can choose to a Lesson only once.";              
            }

            StudentLesson studentLesson = new StudentLesson()
            {
                StudentId = studentId,
                LessonId = lessonId
            };
            var studentLessonDb= await _studentLessonWriteRepository.AddAsync(studentLesson);        
        }
    }
}
