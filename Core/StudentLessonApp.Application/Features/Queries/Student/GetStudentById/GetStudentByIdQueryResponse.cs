using StudentLessonApp.Application.DTOs.Student;


namespace StudentLessonApp.Application.Features.Queries.Student.GetStudentById
{
    public class GetStudentByIdQueryResponse
    {
        public ProfileInfoDto ProfileInfo { get; set; }
        public GetStudentByIdQueryResponse(ProfileInfoDto profileInfo)
        {
            ProfileInfo = profileInfo;
        }
    }
}
