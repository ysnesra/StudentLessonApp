﻿

namespace StudentLessonApp.Application.DTOs.Student
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public StudentDto StudentDto { get; set; }
    }
}
