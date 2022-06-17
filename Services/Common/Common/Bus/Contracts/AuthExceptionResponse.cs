namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthExceptionResponse
    {
        public string Message { get; set; }

        public AuthExceptionResponse(string message)
        {
            Message = message;
        }
    }
}
