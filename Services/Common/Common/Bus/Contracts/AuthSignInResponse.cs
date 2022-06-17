namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthSignInResponse : IAuthSignInResponse
    {
        public AuthToken? Token { get; set; }

        public AuthSignInResponse(AuthToken? token)
        {
            Token = token;
        }
    }
}