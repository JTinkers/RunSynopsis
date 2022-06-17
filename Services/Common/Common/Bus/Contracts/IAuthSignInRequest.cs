namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthSignInRequest
    {
        string Username { get; set; }

        string Password { get; set; }
    }
}