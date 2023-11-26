using MediatR;

namespace StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent
{
    public class SelectLessonByStudentCommandRequest : IRequest<SelectLessonByStudentCommandResponse>
    {
        public List<Guid> LessonIds { get; set; }

    }
}


