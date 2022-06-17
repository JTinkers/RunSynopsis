namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthGetTokenByValueResponse
    {
        AuthToken? Token { get; set; }
    }
}