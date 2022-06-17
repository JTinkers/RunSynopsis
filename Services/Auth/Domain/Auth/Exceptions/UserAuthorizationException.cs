using System.Runtime.Serialization;

namespace RunSynopsis.Domain.Auth.Exceptions
{
    [Serializable]
    public class UserAuthorizationException : Exception
    {
        public UserAuthorizationException()
        {
        }

        public UserAuthorizationException(string? message) : base(message)
        {
        }

        public UserAuthorizationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserAuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}