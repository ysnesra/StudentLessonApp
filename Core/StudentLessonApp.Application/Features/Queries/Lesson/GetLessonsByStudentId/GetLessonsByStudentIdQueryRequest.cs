using MediatR;

namespace StudentLessonApp.Application.Features.Queries.Lesson.GetLessonsByStudentId
{
    public class GetLessonsByStudentIdQueryRequest : IRequest<GetLessonsByStudentIdQueryResponse>
    {
    }
}
