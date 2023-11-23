
using Microsoft.EntityFrameworkCore;
using StudentLessonApp.Domain.Entities;


namespace StudentLessonApp.Persistence.Contexts
{
    public class StudentLessonAppDbContext : DbContext
    {
       
        public StudentLessonAppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
              optionsBuilder.UseNpgsql(Configuration.ConnectionString);
              optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
