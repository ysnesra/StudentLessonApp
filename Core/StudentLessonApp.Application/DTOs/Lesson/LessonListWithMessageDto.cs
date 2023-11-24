
using StudentLessonApp.Application.DTOs.Student;

namespace StudentLessonApp.Application.DTOs.Lesson
{
    public class LessonListWithMessageDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ICollection<LessonListDto> LessonListDto { get; set; }
    }
}
