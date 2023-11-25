using AutoMapper;
using MediatR;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Lesson;


namespace StudentLessonApp.Application.Features.Queries.Lesson.GetAllLesson
{
    public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonQueryRequest, GetAllLessonQueryResponse>
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public GetAllLessonQueryHandler(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        public async Task<GetAllLessonQueryResponse> Handle(GetAllLessonQueryRequest request, CancellationToken cancellationToken)
        {
            ICollection<LessonListDto?> lessons = await _lessonService.GetAllLessonFromRedisAsync();

            LessonListWithMessageDto lessonListWithMessageDto = new LessonListWithMessageDto();
            if (lessons is null)
            {
                lessonListWithMessageDto.Success = false;            
                lessonListWithMessageDto.Message = "Lesson list not found.";
                lessonListWithMessageDto.LessonListDto = [];
                return new GetAllLessonQueryResponse(lessonListWithMessageDto);
                
            }
            lessonListWithMessageDto.Success = true;
            lessonListWithMessageDto.Message = "Lesson listed succesfully.";
            lessonListWithMessageDto.LessonListDto = lessons;
            return new GetAllLessonQueryResponse(lessonListWithMessageDto);         
        }
    }
}
