using StudentLessonApp.Application.DTOs.Student;


namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface IAuthService 
    {
        Task<LoginResponseDto> LoginAsync(LoginStudentDto loginStudentDto);
    }
}
