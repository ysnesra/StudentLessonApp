using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentLessonApp.Application.Behaviors;
using System.Reflection;


namespace StudentLessonApp.Application
{
    public static class ApplicationConfig
    {
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var mappingProfiles = types.Where(type => type.IsAssignableTo(typeof(Profile)));

            foreach (var mappingProfile in mappingProfiles)
                services.AddAutoMapper(mappingProfile);
        }
    }
}
