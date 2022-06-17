using System.Runtime.Serialization;

namespace RunSynopsis.Common.Exceptions
{
    [Serializable]
    public class EntityNotFoundException<TEntity> : Exception
    {
        public override string Message => $"Entity {typeof(TEntity).Name} was not found";

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) 
            : base(message)
        {
        }

        public EntityNotFoundException(string? message, Exception? innerException) 
            : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
