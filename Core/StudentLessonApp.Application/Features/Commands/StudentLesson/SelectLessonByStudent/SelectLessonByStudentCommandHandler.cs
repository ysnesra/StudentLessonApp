using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.StudentLesson;
using System.Security.Claims;


namespace StudentLessonApp.Application.Features.Commands.StudentLesson.SelectLessonByStudent
{
    public class SelectLessonByStudentCommandHandler : IRequestHandler<SelectLessonByStudentCommandRequest, SelectLessonByStudentCommandResponse>
    {
        private readonly IStudentLessonService _studentLessonService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SelectLessonByStudentCommandHandler(IStudentLessonService studentLessonService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _studentLessonService = studentLessonService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SelectLessonByStudentCommandResponse> Handle(SelectLessonByStudentCommandRequest request, CancellationToken cancellationToken)
        {
            Guid studentId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var res = await _studentLessonService.SelectLessonByStudentAsync(studentId, request.LessonIds);


            var studentLessonResponseDto = _mapper.Map<StudentLessonResponseDto>(res);
            
            return new SelectLessonByStudentCommandResponse(studentLessonResponseDto);
        }
    }
}