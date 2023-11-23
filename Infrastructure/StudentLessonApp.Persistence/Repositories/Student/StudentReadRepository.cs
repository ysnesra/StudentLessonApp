

using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Contexts;

namespace StudentLessonApp.Persistence.Repositories
{
    public class StudentReadRepository : ReadRepository<Student>, IStudentReadRepository
    {
        public StudentReadRepository(StudentLessonAppDbContext context) : base(context)
        {
            
        }
    }
}
