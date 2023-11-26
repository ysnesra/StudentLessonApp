

namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface ICacheableRequest
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
