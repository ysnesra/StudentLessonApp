using AutoMapper;
using StudentLessonApp.Application.DTOs.Lesson;
using StudentLessonApp.Application.DTOs.Student;
using StudentLessonApp.Domain.Entities;

namespace StudentLessonApp.Application.Mapping
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<Lesson, LessonListDto>();

            CreateMap<Lesson, LessonInfoDto>();
            CreateMap<Lesson, LessonDetailDto>(); 

            CreateMap<Lesson, LessonsBelongStudentDto>(); 
        }
    }
}
