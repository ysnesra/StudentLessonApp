﻿using AutoMapper;
using StudentLessonApp.Application.Abstractions.Services;
using StudentLessonApp.Application.DTOs.Student;
using StudentLessonApp.Application.Exceptions.Student;
using StudentLessonApp.Application.Repositories;
using StudentLessonApp.Domain.Entities;


namespace StudentLessonApp.Persistence.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;

        public StudentService(IMapper mapper, IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository)
        {
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
        }
        private async Task<Student?> _GetByUserNameAsync(string userName)
        {
            return await _studentReadRepository.GetFirstAsync(student => student.UserName == userName);
        }
        private async Task<Student?> _GetByEmailAsync(string email)
        {
            return await _studentReadRepository.GetFirstAsync(student => student.Email == email);
        }
        private async Task<Student?> _GetByPhoneAsync(string phone)
        {
            return await _studentReadRepository.GetFirstAsync(student => student.Phone == phone);
        }
        private async Task<CheckDuplicateStudentDto> _CheckDuplicateStudentAsync(RegisterStudentDto registerStudentDto)
        {
            var studentDuplicateName = await _GetByUserNameAsync(registerStudentDto.UserName);
            if (studentDuplicateName is not null)
            {
                var CheckDuplicateStudentDto = new
                {
                    Success = false,
                    Message = "This student userName is existed in the system. Please enter another userName."
                };
            }
            var studentDuplicateEmail = await _GetByEmailAsync(registerStudentDto.Email);
            if (studentDuplicateEmail is not null)
            {
                var CheckDuplicateStudentDto = new
                {
                    Success = false,
                    Message = "This student email is existed in the system. Please enter another email."
                };
            }
            var studentDuplicatePhone = await _GetByPhoneAsync(registerStudentDto.Phone);
            if (studentDuplicatePhone is not null)
            {
                var CheckDuplicateStudentDto = new
                {
                    Success = false,
                    Message = "This student phone is existed in the system. Please enter another phone."
                };
            }
            return new CheckDuplicateStudentDto
            {
                Success = true,
                Message = "There is no other registered student in this information."
            };

        }

        public async Task<RegiterResponseDto> RegisterAsync(RegisterStudentDto registerStudentDto)
        {
            await _CheckDuplicateStudentAsync(registerStudentDto);

            var student = _mapper.Map<Student>(registerStudentDto);
            student.Id = Guid.NewGuid();
            var studentCreateResult = await _studentWriteRepository.AddAsync(student);
            if (!studentCreateResult)
            {
                RegiterResponseDto regiterResponseDto = new RegiterResponseDto
                {
                    Success = false,
                    Message = "The student could not be registered."
                };
            }
            return new RegiterResponseDto
            {
                Success = true,
                Message = "The student registered successfully.",
                Id = student.Id,
            };
        }

        public async Task<ProfileInfoDto?> GetByIdAsync(Guid id, bool tracking = true)
        {
            ProfileInfoDto profileInfoDto = new ProfileInfoDto();
            Student student = await _studentReadRepository.GetByIdAsync(id, tracking);
            if (student is null)
            {
                profileInfoDto.Success = false;
                profileInfoDto.Message = "Student information not found.";
                return profileInfoDto;
            }

            profileInfoDto.Success = true;
            profileInfoDto.Message = "Student information displayed successfully.";
            profileInfoDto.StudentInfoDto = _mapper.Map<StudentInfoDto>(student);

            return profileInfoDto;

        }

        public async Task<LoginResponseDto?> CheckLoginAsync(LoginStudentDto loginStudentDto)
        {
            LoginResponseDto loginResponseDto = new LoginResponseDto();
            Student student = await _GetByUserNameAsync(loginStudentDto.UserName);
            if (student is null)
            {
                loginResponseDto.Success = false;
                loginResponseDto.Message = "Student username not found.";
                return loginResponseDto;
            }

            if (student.Password != loginStudentDto.Password)
            {
                loginResponseDto.Success = false;
                loginResponseDto.Message = "Password not match.";
                return loginResponseDto;
            }

            loginResponseDto.Success = true;
            loginResponseDto.Message = "Student has been successfully login. ";
            loginResponseDto.StudentDto = _mapper.Map<StudentDto>(student);

            return loginResponseDto;
        }
    }
}
