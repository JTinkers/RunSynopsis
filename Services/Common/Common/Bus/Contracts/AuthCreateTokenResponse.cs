namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthCreateTokenResponse : IAuthCreateTokenResponse
    {
        public AuthToken Token { get; set; }

        public AuthCreateTokenResponse(AuthToken token)
        {
            Token = token;
        }
    }
}
