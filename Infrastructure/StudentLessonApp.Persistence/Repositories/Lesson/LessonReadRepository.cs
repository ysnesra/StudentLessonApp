using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Contexts;

namespace StudentLessonApp.Persistence.Repositories
{
    public class LessonReadRepository : ReadRepository<Lesson>, ILessonReadRepository
    {
        public LessonReadRepository(StudentLessonAppDbContext context) : base(context)
        {

        }
    }
}
