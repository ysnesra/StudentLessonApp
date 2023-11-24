using AutoMapper;
using StudentLessonApp.Application.DTOs.Lesson;
using StudentLessonApp.Domain.Entities;

namespace StudentLessonApp.Application.Mapping
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<Lesson, LessonListDto>();
         //   CreateMap<List<Lesson>, List<LessonListDto>>();
        }
    }
}
