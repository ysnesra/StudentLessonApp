using StudentLessonApp.Domain.Exceptions;


namespace StudentLessonApp.Application.Exceptions.Student
{
    public class ExistStudentEmailException : BaseException
    {
        public ExistStudentEmailException() : base("This student email is existed in the system. Please enter another student email.")
        {
            
        }
    }
}
