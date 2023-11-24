using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent;
using StudentLessonApp.Infrastructure.Base;


namespace StudentLessonApp.WEB.Controllers
{
    [Authorize]
    public class StudentLessonController : BaseController
    {
        public StudentLessonController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
        }

        [HttpPost]
        public async Task<IActionResult> SelectLessonsAsync(SelectLessonByStudentCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                SelectLessonByStudentCommandResponse response = await Mediator.Send(request);

                if (response is not null)
                    return RedirectToAction("AllLessons", "Lesson");
                else
                    ModelState.AddModelError("", "Lesson selected successfully");
                return View();
            }
            return View();
        }  
    }
}
