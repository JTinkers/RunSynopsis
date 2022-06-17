namespace RunSynopsis.Server.Tracking
{
    public interface ITrackingContextProvider
    {
        string Get();

        void Set(string tracker);
    }
}