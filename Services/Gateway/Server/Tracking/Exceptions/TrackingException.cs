using System.Runtime.Serialization;

namespace RunSynopsis.Server.Tracking.Exceptions
{
    [Serializable]
    public class TrackingException : Exception
    {
        public TrackingException()
        {
        }

        public TrackingException(string? message) : base(message)
        {
        }

        public TrackingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TrackingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}