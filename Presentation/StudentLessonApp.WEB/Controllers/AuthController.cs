using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;
using StudentLessonApp.Infrastructure.Base;
using StudentLessonApp.Application.Features.Commands.Student.LoginStudent;


namespace StudentLessonApp.WEB.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {

        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginStudentCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                LoginStudentCommandResponse response = await Mediator.Send(request);
                if (response.LoginResponseDto.Success)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, response.LoginResponseDto.StudentDto.Id.ToString()));
                    claims.Add(new Claim("UserName", response.LoginResponseDto.StudentDto.UserName));
                    claims.Add(new Claim("Email", response.LoginResponseDto.StudentDto.Email));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Profile", "Student");
                }
                else
                {
                    ModelState.AddModelError("", response.LoginResponseDto.Message);
                    return View(request);
                }
            }
            return View(request);
        }
    }
}
