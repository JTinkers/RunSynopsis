namespace RunSynopsis.Server.Throttling
{
    public interface IThrottlingIdentityProvider
    {
        string Get();

        void Set(string identity);
    }
}