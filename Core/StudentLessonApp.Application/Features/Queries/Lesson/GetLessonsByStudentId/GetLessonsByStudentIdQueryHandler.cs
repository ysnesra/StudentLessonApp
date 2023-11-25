using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Lesson;
using System.Security.Claims;


namespace StudentLessonApp.Application.Features.Queries.Lesson.GetLessonsByStudentId
{
    public class GetLessonsByStudentIdQueryHandler : IRequestHandler<GetLessonsByStudentIdQueryRequest, GetLessonsByStudentIdQueryResponse>
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetLessonsByStudentIdQueryHandler(ILessonService lessonService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _lessonService = lessonService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetLessonsByStudentIdQueryResponse> Handle(GetLessonsByStudentIdQueryRequest request, CancellationToken cancellationToken)
        {
            Guid studentId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            ICollection<LessonsBelongStudentDto?> lessons = await _lessonService.GetLessonsByStudentIdAsync(studentId);

            LessonBelongStudentInfoDto lessonBelongStudentInfoDto = new LessonBelongStudentInfoDto();
            if (lessons is null)
            {
                lessonBelongStudentInfoDto.Success = false;
                lessonBelongStudentInfoDto.Message = "Lessons belongig student not found.";
                lessonBelongStudentInfoDto.LessonsBelongStudentDto = [];
                return new GetLessonsByStudentIdQueryResponse(lessonBelongStudentInfoDto);

            }
            lessonBelongStudentInfoDto.Success = true;
            lessonBelongStudentInfoDto.Message = "Lessons belongig student listed succesfully.";
            lessonBelongStudentInfoDto.LessonsBelongStudentDto = lessons;
            return new GetLessonsByStudentIdQueryResponse(lessonBelongStudentInfoDto);
        }
    }
}