using StudentLessonApp.Application.DTOs.Student;


namespace StudentLessonApp.Application.Features.Commands.Student.LoginStudent
{
    public class LoginStudentCommandResponse 
    {
        public LoginResponseDto LoginResponseDto { get; set; }

        public LoginStudentCommandResponse(LoginResponseDto loginResponseDto)
        {
            LoginResponseDto = loginResponseDto;

        }
    }
}