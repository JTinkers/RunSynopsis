namespace RunSynopsis.Server.Auth.Entities
{
    public class Token
    {
        public string Value { get; set; }

        public long UserId { get; set; }

        public TokenType Type { get; set; }
    }
}