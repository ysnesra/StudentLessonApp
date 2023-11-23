using StudentLessonApp.Domain.Exceptions;


namespace StudentLessonApp.Application.Exceptions.Student
{
    public class ExistStudentUserNameException : BaseException
    {
        public ExistStudentUserNameException() : base("This student UserName is existed in the system. Please enter another student UserName.")
        {
            
        }
    }
}
