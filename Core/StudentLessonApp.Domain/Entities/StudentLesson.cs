using StudentLessonApp.Domain.Entities.Common;


namespace StudentLessonApp.Domain.Entities
{
    public class StudentLesson : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid LessonId { get; set; }
    }
}
