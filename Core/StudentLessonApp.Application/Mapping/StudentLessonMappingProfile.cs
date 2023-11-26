using AutoMapper;
using StudentLessonApp.Application.DTOs.StudentLesson;
using StudentLessonApp.Domain.Entities;


namespace StudentLessonApp.Application.Mapping
{
    public class StudentLessonMappingProfile : Profile
    {
        public StudentLessonMappingProfile()
        {
            //CreateMap<StudentLessonResponseDto, SelectLessonByStudentDto>()
            //  .ForMember(dest => dest.StudentLessonsDto, opt => opt.MapFrom(src => src.StudentLessonsDto))
            //  .ReverseMap();
            CreateMap<StudentLessonResponseDto, SelectLessonByStudentDto>()
           .ForMember(dest => dest.StudentLessonsDto, opt => opt.MapFrom(src => src.StudentLessonsDto ?? new List<StudentLessonsDto>()))
           .ReverseMap();

            CreateMap<StudentLessonsDto, StudentLessonResponseDto>();

            CreateMap<StudentLessonsDto, StudentLesson>();
            
        }
    }
}
