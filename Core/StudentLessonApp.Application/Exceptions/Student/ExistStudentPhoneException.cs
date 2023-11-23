using StudentLessonApp.Domain.Exceptions;


namespace StudentLessonApp.Application.Exceptions.Student
{
    public class ExistStudentPhoneException : BaseException
    {
        public ExistStudentPhoneException() : base("This student phone is existed in the system. Please enter another student phone.")
        {

        }
    }
}