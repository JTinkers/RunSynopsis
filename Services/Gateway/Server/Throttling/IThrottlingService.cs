namespace RunSynopsis.Server.Throttling
{
    public interface IThrottlingService
    {
        Task<bool> CanExecuteAsync();

        Task RegisterExecutionAsync();
    }
}