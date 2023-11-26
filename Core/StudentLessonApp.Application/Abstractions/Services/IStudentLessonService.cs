

using StudentLessonApp.Application.DTOs.StudentLesson;

namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface IStudentLessonService
    {
        // Task SelectLessonByStudentAsync(Guid studentId, Guid lessonIds);
        Task<SelectLessonByStudentDto> SelectLessonByStudentAsync(Guid studentId, List<Guid> lessonIds);
    }
}
