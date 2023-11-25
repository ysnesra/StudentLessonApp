using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLessonApp.Application.DTOs.Lesson
{
    public class LessonBelongStudentInfoDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ICollection<LessonsBelongStudentDto> LessonsBelongStudentDto { get; set; }
    }
}
