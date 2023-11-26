

using StudentLessonApp.Application.DTOs.Lesson;
using StudentLessonApp.Application.DTOs.StudentLesson;

namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface IStudentLessonService
    {
        Task<SelectLessonByStudentDto> SelectLessonByStudentAsync(Guid studentId, List<Guid> lessonIds);
        Task<List<LessonsBelongStudentDto?>> GetLessonsByStudentIdAsync(Guid studentId);
    }
}
