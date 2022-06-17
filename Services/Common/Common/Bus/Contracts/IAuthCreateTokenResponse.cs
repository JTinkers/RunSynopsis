namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthCreateTokenResponse
    {
        AuthToken Token { get; set; }
    }
}