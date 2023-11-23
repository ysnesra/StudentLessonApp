using AutoMapper;
using MediatR;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Student;


namespace StudentLessonApp.Application.Features.Commands.Student.LoginStudent
{
    public class LoginStudentCommandHandler : IRequestHandler<LoginStudentCommandRequest, LoginStudentCommandResponse>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginStudentCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<LoginStudentCommandResponse> Handle(LoginStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var studentDto = _mapper.Map<LoginStudentDto>(request);
            var student = await _authService.LoginAsync(studentDto);
            return new LoginStudentCommandResponse (student);
        }
    }
}
