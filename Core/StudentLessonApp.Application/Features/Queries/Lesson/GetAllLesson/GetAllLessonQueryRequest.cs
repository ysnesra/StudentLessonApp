using MediatR;
using StudentLessonApp.Application.Abstractions.Services;

namespace StudentLessonApp.Application.Features.Queries.Lesson.GetAllLesson
{
    public class GetAllLessonQueryRequest : IRequest<GetAllLessonQueryResponse>/*, ICacheableRequest*/
    {
        //public bool BypassCache { get; set; }
        //public string CacheKey => $"LessonList";
        //public TimeSpan? SlidingExpiration { get; set; }
    }
}
