using AutoMapper;
using MediatR;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Student;

namespace StudentLessonApp.Application.Features.Commands.Student.RegisterStudent
{
    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommandRequest, RegisterStudentCommandResponse>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public RegisterStudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<RegisterStudentCommandResponse> Handle(RegisterStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var studentDto = _mapper.Map<RegisterStudentDto>(request);
            var student=await _studentService.RegisterAsync(studentDto);
            return new(student.Id);
        }
    }
}
