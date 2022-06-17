using MediatR;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth.Events
{
    public class AuthUserUpdated : INotification
    {
        public User User { get; set; }

        public AuthUserUpdated(User user)
        {
            User = user;
        }
    }
}