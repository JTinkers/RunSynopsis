namespace RunSynopsis.Domain.Auth.Entities
{
    public class Token
    {
        public string Value { get; set; }

        public long UserId { get; set; }

        public TokenType Type { get; set; }

        public virtual User User { get; set; }

        public Token()
        {
        }

        public Token(User user, TokenType type, string value)
        {
            User = user;
            UserId = user.Id;
            Type = type;
            Value = value;
        }

        public Token(long userId, TokenType type, string value)
        {
            UserId = userId;
            Type = type;
            Value = value;
        }
    }
}