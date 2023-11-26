using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentLessonApp.Application.Behaviors;

namespace StudentLessonApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection, ConfigurationManager _configurationManager)
        {
            ApplicationConfig.ConfigureAutoMapper(collection);
            _configurationManager.GetSection("FilePathSettings");

        }
        public static void AddDistributedCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(option => {
                option.Configuration = "127.0.0.1:6380";
            });

            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));
        }
    }
}
