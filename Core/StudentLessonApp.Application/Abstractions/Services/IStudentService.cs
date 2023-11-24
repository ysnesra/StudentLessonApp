using StudentLessonApp.Application.DTOs.Student;
using StudentLessonApp.Domain.Entities;


namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Student> RegisterAsync(RegisterStudentDto registerStudentDto);
        //Task<Student> UpdateAsync(UpdateStudentCommandRequest request);
        //Task RemoveAsync(Guid id);
        Task<ProfileInfoDto?> GetByIdAsync(Guid id, bool tracking = true);
        Task<LoginResponseDto?> CheckLoginAsync(LoginStudentDto loginStudentDto);
    }
}
