using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Contexts;

namespace StudentLessonApp.Persistence.Repositories
{
    public class StudentLessonWriteRepository : WriteRepository<StudentLesson>, IStudentLessonWriteRepository
    {
        public StudentLessonWriteRepository(StudentLessonAppDbContext context) : base(context)
        {
        }
    }
}

