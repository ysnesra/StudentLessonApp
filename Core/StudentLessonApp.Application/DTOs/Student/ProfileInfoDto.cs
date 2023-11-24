
namespace StudentLessonApp.Application.DTOs.Student
{
    public class ProfileInfoDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public StudentInfoDto StudentInfoDto { get; set; }
    }
}
