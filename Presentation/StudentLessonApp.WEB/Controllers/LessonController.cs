using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent;
using StudentLessonApp.Application.Features.Queries.Lesson.GetAllLesson;
using StudentLessonApp.Application.Features.Queries.Lesson.GetLessonsByStudentId;
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
                return View(response.LessonListWithMessageDtos.Message);
            }
            return View(response);
        }

        [HttpPost]
        public async Task<JsonResult> SaveAllLessons([FromBody] string[] LessonId)
        {
            if (ModelState.IsValid)
            {
                SelectLessonByStudentCommandRequest request = new SelectLessonByStudentCommandRequest();

                List<Guid> less = new List<Guid>();

                foreach (var item in LessonId)
                {
                    less.Add(Guid.Parse(item));
                }

                request.LessonIds = less;

                SelectLessonByStudentCommandResponse response = await Mediator.Send(request);

                if (response.StudentLessonResponseDto.Success)
                    return Json("Ok");
                else
                    return Json(new { error = response.StudentLessonResponseDto.Message });
            }
            return Json(new { error = "Invalid model state" });
        }

        [HttpGet]
        public async Task<IActionResult> MyLessons(GetLessonsByStudentIdQueryRequest request)
        {
            GetLessonsByStudentIdQueryResponse response = await Mediator.Send(request);

            if (!response.LessonBelongStudentInfoDto.Success)
            {
                return View(response.LessonBelongStudentInfoDto.Message);
            }
            return View(response);
        }

    }
}
