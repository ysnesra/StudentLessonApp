using StudentLessonApp.Domain.Entities.Common;


namespace StudentLessonApp.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public Lesson()
        {
            Students=new HashSet<Student>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
