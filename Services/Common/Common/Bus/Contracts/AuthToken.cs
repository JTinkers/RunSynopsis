namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthToken
    {
        public string Value { get; set; }

        public long UserId { get; set; }

        public AuthTokenType Type { get; set; }

        public AuthToken(AuthTokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}