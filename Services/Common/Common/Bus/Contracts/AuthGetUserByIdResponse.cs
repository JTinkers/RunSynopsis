namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthGetUserByIdResponse : IAuthGetUserByIdResponse
    {
        public AuthUser? User { get; set; }

        public AuthGetUserByIdResponse(AuthUser? user)
        {
            User = user;
        }
    }
}