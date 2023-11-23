using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace StudentLessonApp.Infrastructure.Base
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator Mediator;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseController(IMediator mediator,IHttpContextAccessor httpContextAccessor)
        {
            Mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
