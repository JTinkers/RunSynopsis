namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthGetUserByIdResponse
    {
        AuthUser? User { get; set; }
    }
}