using MediatR;
using StudentLessonApp.Application.Features.Commands.Student.RegisterStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLessonApp.Application.Features.Commands.Student.LoginStudent
{
    public class LoginStudentCommandRequest : IRequest<LoginStudentCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
