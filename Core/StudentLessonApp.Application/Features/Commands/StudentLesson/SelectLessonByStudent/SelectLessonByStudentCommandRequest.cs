using MediatR;

namespace StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent
{
    public class SelectLessonByStudentCommandRequest : IRequest<SelectLessonByStudentCommandResponse>
    {
        public ICollection<Guid> LessonIds { get; set; }

    }
}


