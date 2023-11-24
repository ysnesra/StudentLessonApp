using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLessonApp.Application.Features.Queries.Lesson.GetAllLesson;
using StudentLessonApp.Infrastructure.Base;

namespace StudentLessonApp.WEB.Controllers
{
    [Authorize]
    public class LessonController :BaseController
    {
        public LessonController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllLessons(GetAllLessonQueryRequest request)
        {
            GetAllLessonQueryResponse response = await Mediator.Send(request);

            if (!response.LessonListWithMessageDtos.Success)
            {
                return View(response);
            }
            return View(response);
        }
    }
}
