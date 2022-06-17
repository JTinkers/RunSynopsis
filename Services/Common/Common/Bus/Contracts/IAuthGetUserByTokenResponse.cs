namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthGetUserByTokenResponse
    {
        AuthUser? User { get; set; }
    }
}