namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthGetUserByTokenRequest : IAuthGetUserByTokenRequest
    {
        public string Value { get; set; }

        public AuthTokenType Type { get; set; }

        public AuthGetUserByTokenRequest(AuthTokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}