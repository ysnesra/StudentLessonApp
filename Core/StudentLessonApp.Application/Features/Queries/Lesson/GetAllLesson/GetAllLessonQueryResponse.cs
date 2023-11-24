using StudentLessonApp.Application.DTOs.Lesson;

namespace StudentLessonApp.Application.Features.Queries.Lesson.GetAllLesson
{
    public class GetAllLessonQueryResponse
    {
       public LessonListWithMessageDto LessonListWithMessageDtos { get; set; }
        public GetAllLessonQueryResponse(LessonListWithMessageDto lessonListWithMessageDtos)
        {
            LessonListWithMessageDtos = lessonListWithMessageDtos;  
        }
    }
}
