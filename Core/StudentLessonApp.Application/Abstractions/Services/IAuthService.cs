using StudentLessonApp.Application.DTOs.Student;
using StudentLessonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface IAuthService 
    {
        Task<LoginResponseDto> LoginAsync(LoginStudentDto loginStudentDto);
    }
}
