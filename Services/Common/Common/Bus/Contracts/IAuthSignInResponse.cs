namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthSignInResponse
    {
        AuthToken? Token { get; set; }
    }
}