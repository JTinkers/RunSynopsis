namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthGetUserByTokenRequest
    {
        AuthTokenType Type { get; set; }

        string Value { get; set; }
    }
}