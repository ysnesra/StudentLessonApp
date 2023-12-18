using StudentLessonApp.Domain.Entities.Common;


namespace StudentLessonApp.Domain.Entities
{
    public class Student : BaseEntity
    {
       
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
      
    }
}
