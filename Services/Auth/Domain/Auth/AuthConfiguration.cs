using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth
{
    public class AuthConfiguration
    {
        public IDictionary<TokenType, int> TokenTtl { get; set; }
    }
}