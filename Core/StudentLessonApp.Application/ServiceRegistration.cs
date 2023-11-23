using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace StudentLessonApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection, ConfigurationManager _configurationManager)
        {
            ApplicationConfig.ConfigureAutoMapper(collection);
            _configurationManager.GetSection("FilePathSettings");

        }
    }
}
