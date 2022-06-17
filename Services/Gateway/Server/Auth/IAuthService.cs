using RunSynopsis.Server.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public interface IAuthService
    {
        Task<Token?> SignInAsync(string username, string password);

        Task<User?> GetUserByTokenAsync(TokenType type, string value);

        Task<Token?> GetTokenByValueAsync(string value);
    }
}