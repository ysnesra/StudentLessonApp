using StudentLessonApp.Application.Features.Commands.Response;


namespace StudentLessonApp.Application.Features.Commands.Student.RegisterStudent
{
    public class RegisterStudentCommandResponse : BaseResponse
    {
        public Guid StudentId { get; set; }

        public RegisterStudentCommandResponse(Guid studentId)
        {
            StudentId = studentId;
            Message = $"The student with ID {studentId} has been successfully registered in.";
        }
    }
}

