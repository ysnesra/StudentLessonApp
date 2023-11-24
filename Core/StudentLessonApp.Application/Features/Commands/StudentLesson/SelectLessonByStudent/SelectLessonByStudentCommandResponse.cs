using StudentLessonApp.Application.DTOs.StudentLesson;

namespace StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent
{
    public class SelectLessonByStudentCommandResponse
    {
        public StudentLessonResponseDto StudentLessonResponseDto { get; set; }

        public SelectLessonByStudentCommandResponse(StudentLessonResponseDto studentLessonResponseDto)
        {
            StudentLessonResponseDto = studentLessonResponseDto;

        }
    }
}

