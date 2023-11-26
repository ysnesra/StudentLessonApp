

using MediatR;


namespace StudentLessonApp.Application.Abstractions.Services
{
    public interface ICacheableRequest<TResponse> : IRequest<TResponse>
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
