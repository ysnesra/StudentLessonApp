using StudentLessonApp.Domain.Entities.Common;


namespace StudentLessonApp.Domain.Entities
{
    public class Lesson : BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
