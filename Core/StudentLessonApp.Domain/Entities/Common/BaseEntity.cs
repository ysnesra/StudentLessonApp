using StudentLessonApp.Domain.Interfaces.Common;
using System.ComponentModel.DataAnnotations;


namespace StudentLessonApp.Domain.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        [Key] 
        public Guid Id { get; set; }
    }
}
