using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLessonApp.Application.Features.Commands.Student.RegisterStudent;
using StudentLessonApp.Infrastructure.Base;

namespace StudentLessonApp.WEB.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        public StudentController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {

        }
    
        public IActionResult ProfileStudent()
        {
            return View();  //aynı sayfaya dön
        }

        //ÜyeOl Ekranı formu
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
                    return RedirectToAction(nameof(ProfileStudent));
                else
                    ModelState.AddModelError("", "Sign in failed");
            }
            return View();
        }

        //Student Bilgileri Id ye göre dolu gelme
        [HttpGet]
        public IActionResult ProfileInfo()
        {
            //ProfileInfoLoader();
            return View();
        }
    }
}
