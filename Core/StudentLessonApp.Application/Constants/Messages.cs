

namespace StudentLessonApp.Application.Constants
{
    public static class Messages
    {
        public static string StudentInfoNotFound = "Student information not found.";
        public static string StudentInfoSuccess = "Student information displayed successfully.";
        public static string LessonSelectedSuccess = "Lessons selected successfully.";
        public static string StudentNameExisted = "This student userName is existed in the system. Please enter another userName.";
        public static string StudentEmailExisted = "This student email is existed in the system. Please enter another email.";
        public static string StudentPhoneExisted = "This student phone is existed in the system. Please enter another phone.";
        public static string StudentFirstRegistered = "There is no other registered student in this information.";
        public static string StudentRegisteredFailed = "The student could not be registered.";
        public static string StudentRegisteredSuccess = "The student registered successfully.";
        public static string StudentUsernameNotFound = "Student username not found.";
        public static string PasswordNotMatch = "Password not match.";
        public static string StudentLoginSuccess = "Student has been successfully login.";
        

        public static string LessonNotFound(string lessonName)
        {
            return $"Lesson with Name {lessonName} does not exist in the system.";
        }

        public static string StudentAlreadyChosenLesson(string lessonName)
        {
            return $"Student has already chosen Lesson with Name {lessonName}.";
        }
    }
}
