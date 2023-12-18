using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.Constants;
using StudentLessonApp.Application.DTOs.Lesson;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;


namespace StudentLessonApp.Persistence.Services
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly ILessonWriteRepository _lessonWriteRepository;

        public LessonService(IMapper mapper, ILessonReadRepository lessonReadRepository, ILessonWriteRepository lessonWriteRepository)
        {
            _mapper = mapper;
            _lessonReadRepository = lessonReadRepository;
            _lessonWriteRepository = lessonWriteRepository;
        }

        public async Task<ICollection<LessonListDto?>> GetAllLessonAsync()
        {
            var lessons = await _lessonReadRepository.GetAll().ToListAsync();

            var lessonsDto = _mapper.Map<ICollection<LessonListDto>>(lessons);
            return lessonsDto;
        }

        public async Task<ICollection<LessonListDto?>> GetAllLessonFromRedisAsync()
        {
            //var lessons = await _lessonReadRepository.GetAll().ToListAsync();
            var lessons = await _lessonReadRepository.GetAllFromRedisAsync();

            var lessonsDto = _mapper.Map<ICollection<LessonListDto>>(lessons);

            return lessonsDto;
        }

        public async Task<LessonInfoDto> GetByIdAsync(Guid id, bool tracking = true)
        {
            LessonInfoDto lessonInfoDto = new LessonInfoDto();
            Lesson lesson = await _lessonReadRepository.GetByIdAsync(id, tracking);
            if (lesson is null)
            {
                lessonInfoDto.Success = false;
                lessonInfoDto.Message =Messages.StudentInfoNotFound;
                return lessonInfoDto;
            }

            lessonInfoDto.Success = true;
            lessonInfoDto.Message = Messages.StudentInfoSuccess;
            lessonInfoDto.LessonDetailDto = _mapper.Map<LessonDetailDto>(lesson);

            return lessonInfoDto;
        }
       
    }
}
