using System.Runtime.Serialization;

namespace RunSynopsis.Domain.Storage.Exceptions
{
    [Serializable]
    public class MediaNotFoundException : Exception
    {
        public MediaNotFoundException()
        {
        }

        public MediaNotFoundException(string message) : base(message)
        {
        }

        public MediaNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MediaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}