using StudentLessonApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLessonApp.Application.Exceptions.Student
{
    public class NotFoundStudentException : BaseException
    {
        public NotFoundStudentException() : base("User not found.")
        {
        }
    }
}
