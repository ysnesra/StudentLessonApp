﻿

namespace StudentLessonApp.Application.DTOs.Student
{
    public class RegisterStudentDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
    }
}
