﻿using StudentLessonApp.Domain.Entities;

namespace StudentLessonApp.Application.Repositories
{
    public interface ILessonReadRepository : IReadRepository<Lesson>
    {
       Task<ICollection<Lesson>> GetAllFromRedisAsync();
    }
}
