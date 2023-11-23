using StudentLessonApp.Domain.Exceptions;


namespace StudentLessonApp.Application.Exceptions.Student
{
    public class RegisterStudentFailedException : BaseException
    {
        public RegisterStudentFailedException() : base("The student could not be created.")
        { 
        }
    }
}

