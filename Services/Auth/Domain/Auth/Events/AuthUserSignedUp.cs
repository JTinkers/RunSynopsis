using MediatR;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth.Events
{
    public class AuthUserSignedUp : INotification
    {
        public User User { get; set; }

        public Token Token { get; set; }

        public AuthUserSignedUp(User user, Token token)
        {
            User = user;
            Token = token;
        }
    }
}