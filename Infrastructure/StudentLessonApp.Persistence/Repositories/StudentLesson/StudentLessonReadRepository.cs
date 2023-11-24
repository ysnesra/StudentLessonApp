using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Contexts;

namespace StudentLessonApp.Persistence.Repositories
{
    public class StudentLessonReadRepository : ReadRepository<StudentLesson>, IStudentLessonReadRepository
    {
        public StudentLessonReadRepository(StudentLessonAppDbContext context) : base(context)
        {

        }
    }
}
