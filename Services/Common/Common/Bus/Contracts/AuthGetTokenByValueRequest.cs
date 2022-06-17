namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthGetTokenByValueRequest : IAuthGetTokenByValueRequest
    {
        public string Value { get; set; }

        public AuthGetTokenByValueRequest(string value)
        {
            Value = value;
        }
    }
}