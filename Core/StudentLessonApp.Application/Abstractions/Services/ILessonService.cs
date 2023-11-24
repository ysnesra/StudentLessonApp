using StudentLessonApp.Application.DTOs.Lesson;


namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface ILessonService
    {
        Task<ICollection<LessonListDto?>> GetAllLessonAsync();
        Task<ICollection<LessonListDto?>> GetAllLessonFromRedisAsync();
    }
}
