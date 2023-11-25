using StudentLessonApp.Application.DTOs.Lesson;


namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface ILessonService
    {
        Task<ICollection<LessonListDto?>> GetAllLessonAsync();
        Task<ICollection<LessonsBelongStudentDto?>> GetLessonsByStudentIdAsync(Guid studentId);
        Task<ICollection<LessonListDto?>> GetAllLessonFromRedisAsync();
        Task<LessonInfoDto> GetByIdAsync(Guid id, bool tracking = true);
    }
}
