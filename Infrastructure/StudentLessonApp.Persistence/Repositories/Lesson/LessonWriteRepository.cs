using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Contexts;

namespace StudentLessonApp.Persistence.Repositories
{
    public class LessonWriteRepository : WriteRepository<Lesson>, ILessonWriteRepository
    {
        public LessonWriteRepository(StudentLessonAppDbContext context) : base(context)
        {
        }
    }
}
