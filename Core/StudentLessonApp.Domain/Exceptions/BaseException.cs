
using System.Runtime.Serialization;


namespace StudentLessonApp.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(string? message) : base(message)
        {
        }

        public BaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}