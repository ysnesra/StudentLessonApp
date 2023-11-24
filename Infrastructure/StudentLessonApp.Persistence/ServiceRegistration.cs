using Microsoft.Extensions.DependencyInjection;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Persistence.Contexts;
using StudentLessonApp.Persistence.Repositories;
using StudentLessonApp.Persistence.Services;


namespace StudentLessonApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<StudentLessonAppDbContext>(options => { }, ServiceLifetime.Scoped);
         
            services.AddHttpContextAccessor();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repository
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();

            services.AddScoped<ILessonWriteRepository, LessonWriteRepository>();
            
            services.AddScoped<IStudentLessonReadRepository, StudentLessonReadRepository>();
            services.AddScoped<IStudentLessonWriteRepository, StudentLessonWriteRepository>();

            // Service
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IStudentLessonService, StudentLessonService>();
            services.AddTransient<IAuthService, AuthService>();

        }
    }
}
