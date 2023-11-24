using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Persistence.Contexts;
using StudentLessonApp.Persistence.Repositories;
using StudentLessonApp.Redis.Repositories;
using StudentLessonApp.Redis.Services;


namespace StudentLessonApp.Redis
{
    public static class ServiceRegistration
    {
        public static void AddRedisServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RedisService>(sp =>
            {
                return new RedisService(configuration["CacheOptions:Url"]);
            });

            //RedisServicedeki default 15 db den 0.cı Db ye bağlanma
            services.AddSingleton<IDatabase>(sp =>
            {
                var redisService = sp.GetRequiredService<RedisService>();
                return redisService.GetDb(0);
            });

            services.AddScoped<ILessonReadRepository>(sp =>
            {
                var appDbContext = sp.GetRequiredService<StudentLessonAppDbContext>();
                var lessonRepository = new LessonReadRepository(appDbContext);
                var redisService = sp.GetRequiredService<RedisService>();
                var redisDatabase = sp.GetRequiredService<IDatabase>();
                return new LessonWithCacheReadRepository(appDbContext, lessonRepository, redisService, redisDatabase);
            });
        }
    }
}
