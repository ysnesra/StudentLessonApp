
using Microsoft.EntityFrameworkCore;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Migrations;


namespace StudentLessonApp.Persistence.Contexts
{
    public class StudentLessonAppDbContext : DbContext
    {

        public StudentLessonAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(Configuration.ConnectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = Guid.Parse("72305372-470f-4b15-8876-f61b72691841"),
                    FullName = "Esra Yaşın",
                    UserName = "esra",
                    Password = "Esra.1",
                    Email = "esra@gmail.com",
                    Phone = "05331545547"
                },
                new Student
                {
                    Id = Guid.Parse("73305372-470f-4b15-8876-f61b72691843"),
                    FullName = "Mehmet Kutlu",
                    UserName = "mehmet",
                    Password = "Mehmet.1",
                    Email = "mehmet@gmail.com",
                    Phone = "05551545547"
                });

            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    Id = Guid.Parse("22905372-470f-4b15-8876-f61b72691841"),
                    Name = "Programming languages1",
                    Description = "Java",
                },
                new Lesson
                {
                    Id = Guid.Parse("23905372-470f-4b15-8876-f61b72691842"),
                    Name = "Programming languages2",
                    Description = "C#",
                },
                new Lesson
                {
                    Id = Guid.Parse("24905372-470f-4b15-8876-f61b72691843"),
                    Name = "Mobile App Development",
                    Description = "React Native and Flutter Frameworks",
                },
                new Lesson
                {
                    Id = Guid.Parse("25905372-470f-4b15-8876-f61b72691843"),
                    Name = "Software Architectures",
                    Description = "MicroServices",
                },
                new Lesson
                {
                    Id = Guid.Parse("26905372-470f-4b15-8876-f61b72691843"),
                    Name = "Data Structures and Algorithms",
                    Description = "Searching-Sorting Algorithms",
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}

