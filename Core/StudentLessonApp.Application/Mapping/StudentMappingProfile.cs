using AutoMapper;
using StudentLessonApp.Application.DTOs.Student;
using StudentLessonApp.Application.Features.Commands.Student.LoginStudent;
using StudentLessonApp.Application.Features.Commands.Student.RegisterStudent;
using StudentLessonApp.Domain.Entities;


namespace StudentLessonApp.Application.Mapping
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<RegisterStudentDto, Student>(); 
            CreateMap<RegisterStudentCommandRequest, RegisterStudentDto>(); 

            CreateMap<LoginStudentCommandRequest, LoginStudentDto>(); 
            CreateMap<Student, StudentDto>(); 

            CreateMap<Student, ProfileInfoDto>();
            CreateMap<Student, StudentInfoDto>();
        }
    }
}
