using StudentLessonApp.Application.DTOs.Student;


namespace StudentLessonApp.Application.Features.Commands.Student.RegisterStudent
{
    public class RegisterStudentCommandResponse 
    {
        public RegiterResponseDto RegiterResponseDto { get; set; }

        public RegisterStudentCommandResponse(RegiterResponseDto regiterResponseDto)
        {
            RegiterResponseDto = regiterResponseDto;

        }
    }
}

