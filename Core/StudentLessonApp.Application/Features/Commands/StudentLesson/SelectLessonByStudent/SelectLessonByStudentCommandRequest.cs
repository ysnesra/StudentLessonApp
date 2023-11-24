using MediatR;

namespace StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent
{
    public class SelectLessonByStudentCommandRequest : IRequest<SelectLessonByStudentCommandResponse>
    {
        public Guid LessonId { get; set; }

    }
}


