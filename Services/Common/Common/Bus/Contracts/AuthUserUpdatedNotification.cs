namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthUserUpdatedNotification : IAuthUserUpdatedNotification
    {
        public AuthUser User { get; set; }

        public AuthUserUpdatedNotification(AuthUser user)
        {
            User = user;
        }
    }
}
