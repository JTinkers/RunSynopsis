using System.Runtime.Serialization;

namespace RunSynopsis.Domain.Auth.Exceptions
{
    [Serializable]
    public class UserAuthenticationException : Exception
    {
        public UserAuthenticationException()
        {
        }

        public UserAuthenticationException(string message) : base(message)
        {
        }

        public UserAuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserAuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}