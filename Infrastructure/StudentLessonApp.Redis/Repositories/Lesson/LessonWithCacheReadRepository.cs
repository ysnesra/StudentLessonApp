using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;
using StudentLessonApp.Persistence.Contexts;
using StudentLessonApp.Persistence.Repositories;
using StudentLessonApp.Redis.Services;
using System.Text.Json;


namespace StudentLessonApp.Redis.Repositories
{
    public class LessonWithCacheReadRepository : ReadRepository<Lesson>, ILessonReadRepository
    {
        //Tablonun Hash setine "lessonCaches" ismini verildi
        private const string lessonKey = "lessonCaches";
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;

        public LessonWithCacheReadRepository(StudentLessonAppDbContext context, ILessonReadRepository lessonReadRepository, RedisService redisService, IDatabase cacheRepository) : base(context)
        {
            _lessonReadRepository = lessonReadRepository;
            _redisService = redisService;
            _cacheRepository = _redisService.GetDb(2);
        }

        //Datayı Cacheleyecek
        private async Task<List<Lesson>> LoadToCacheFromDbAsync()
        {
            var lessons = await _lessonReadRepository.GetAll().ToListAsync();

            lessons.ForEach(lesson =>
            {
                _cacheRepository.HashSetAsync(lessonKey, lesson.Id.ToString(), JsonSerializer.Serialize(lesson));
            });
            return lessons;
        }

        
        public async Task<ICollection<Lesson>> GetAllFromRedisAsync()
        {
            //data cache de yoksa db den cache yükler
            if(!await _cacheRepository.KeyExistsAsync(lessonKey))
                 return await LoadToCacheFromDbAsync();

            var lessons =new List<Lesson>();
            var cacheLessons= await _cacheRepository.HashGetAllAsync(lessonKey);

            foreach (var cacheLesson in cacheLessons.ToList())
            {
                var lesson= JsonSerializer.Deserialize<Lesson>(cacheLesson.Value);
                lessons.Add(lesson);
            }
            return lessons;
        }
    }
}
