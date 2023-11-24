using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLessonApp.Application.Features.Commands.Student.RegisterStudent;
using StudentLessonApp.Application.Features.Queries.Student.GetStudentById;
using StudentLessonApp.Infrastructure.Base;


namespace StudentLessonApp.WEB.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        public StudentController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {

        }
    
        public IActionResult Profile()
        {
            return View();  
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterStudentCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                RegisterStudentCommandResponse response = await Mediator.Send(request);

                if (response is not null)
                    return RedirectToAction(nameof(Profile));
                else
                    ModelState.AddModelError("", "Sign in success");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyInformation(GetStudentByIdQueryRequest request)
        {
            GetStudentByIdQueryResponse response = await Mediator.Send(request);

            if (response.ProfileInfo.Success)
            {
                return View(response);
            }
            return View(response);
        }
    }
}
