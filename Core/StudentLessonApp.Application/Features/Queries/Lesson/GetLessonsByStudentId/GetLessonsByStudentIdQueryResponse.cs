using StudentLessonApp.Application.DTOs.Lesson;


namespace StudentLessonApp.Application.Features.Queries.Lesson.GetLessonsByStudentId
{
    public class GetLessonsByStudentIdQueryResponse
    {
        public LessonBelongStudentInfoDto LessonBelongStudentInfoDto { get; set; }
        public GetLessonsByStudentIdQueryResponse(LessonBelongStudentInfoDto lessonBelongStudentInfoDto)
        {
            LessonBelongStudentInfoDto = lessonBelongStudentInfoDto;
        }
    }
}
