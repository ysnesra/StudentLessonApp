using StudentLessonApp.Application.DTOs.Student;
using StudentLessonApp.Application.Features.Commands.Response;


namespace StudentLessonApp.Application.Features.Commands.Student.LoginStudent
{
    public class LoginStudentCommandResponse :BaseResponse
    {
        public LoginResponseDto LoginResponseDto { get; set; }

        public LoginStudentCommandResponse(LoginResponseDto loginResponseDto)
        {
            LoginResponseDto = loginResponseDto;

        }
    }
}