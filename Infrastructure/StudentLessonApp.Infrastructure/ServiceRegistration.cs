using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StudentLessonApp.Application.Features.Commands.Student.LoginStudent;
using StudentLessonApp.Application.Features.Commands.Student.RegisterStudent;
using StudentLessonApp.Application.Validators.Student;


namespace StudentLessonApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterStudentCommandRequest>, RegisterStudentValidator>();
            services.AddScoped<IValidator<LoginStudentCommandRequest>, LoginStudentValidator>();
            
        }
    }
}
