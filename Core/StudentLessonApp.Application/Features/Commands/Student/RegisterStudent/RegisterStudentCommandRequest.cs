using MediatR;


namespace StudentLessonApp.Application.Features.Commands.Student.RegisterStudent
{
    public class RegisterStudentCommandRequest : IRequest<RegisterStudentCommandResponse>
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
     
    }
}
