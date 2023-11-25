using AutoMapper;
using StudentLessonApp.Application.DTOs.StudentLesson;
using StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent;


namespace StudentLessonApp.Application.Mapping
{
    public class StudentLessonMappingProfile : Profile
    {
        public StudentLessonMappingProfile()
        {
            CreateMap<SelectLessonByStudentCommandRequest, StudentLessonResponseDto>()
           .ForMember(dest => dest.StudentLessonsDto, opt => opt.MapFrom(src => 
                      new StudentLessonsDto { LessonId = src.LessonIds.FirstOrDefault() }))
           .ForMember(dest => dest.Success, opt => opt.MapFrom(_ => true))
           .ForMember(dest => dest.Message, opt => opt.MapFrom(_ => "Lessons selected successfully"));
        }
    }
}
