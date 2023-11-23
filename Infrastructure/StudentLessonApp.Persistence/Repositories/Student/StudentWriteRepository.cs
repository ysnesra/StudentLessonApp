using StudentLessonApp.Persistence.Contexts;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Application.Repositories;


namespace StudentLessonApp.Persistence.Repositories
{
    public class StudentWriteRepository : WriteRepository<Student>, IStudentWriteRepository
    {
        public StudentWriteRepository(StudentLessonAppDbContext context) : base(context)
        {
        }
    }
}
