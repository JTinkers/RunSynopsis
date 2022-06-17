namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthGetUserByTokenResponse
    {
        public AuthUser? User { get; set; }

        public AuthGetUserByTokenResponse(AuthUser? user)
        {
            User = user;
        }
    }
}