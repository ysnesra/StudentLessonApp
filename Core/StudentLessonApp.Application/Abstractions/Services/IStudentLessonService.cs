

namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface IStudentLessonService
    {
        Task SelectLessonByStudentAsync(Guid studentId, Guid lessonId);
    }
}
