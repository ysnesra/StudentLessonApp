using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Student;
using System.Security.Claims;


namespace StudentLessonApp.Application.Features.Queries.Student.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetStudentByIdQueryHandler(IStudentService studentService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _studentService = studentService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Guid studentId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            var student= await _studentService.GetByIdAsync(studentId);
            var mappedStudent = _mapper.Map<ProfileInfoDto>(student); //buna gerek yok sanki
            return new GetStudentByIdQueryResponse (mappedStudent);
        }
    }
}
