

namespace StudentLessonApp.Application.DTOs.StudentLesson
{
    public class StudentLessonResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public StudentLessonsDto StudentLessonsDto { get; set; }
        //public ICollection<StudentLessonsDto> StudentLessonsDto { get; set; }
    }
}
