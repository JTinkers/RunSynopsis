using System.Runtime.Serialization;

namespace RunSynopsis.Domain.Auth.Exceptions
{
    [Serializable]
    public class UserValidationException : Exception
    {
        public UserValidationException()
        {
        }

        public UserValidationException(string? message) : base(message)
        {
        }

        public UserValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}