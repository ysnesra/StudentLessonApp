using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Student;

namespace StudentLessonApp.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IStudentService _studentService;

        public AuthService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginStudentDto loginStudentDto)
        {
            return await _studentService.CheckLoginAsync(loginStudentDto);
        }
    }
}
