using Microsoft.EntityFrameworkCore;
using StudentLessonApp.Domain.Entities.Common;


namespace StudentLessonApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
