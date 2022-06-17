namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthGetTokenByValueResponse
    {
        public AuthToken? Token { get; set; }

        public AuthGetTokenByValueResponse(AuthToken? token)
        {
            Token = token;
        }
    }
}