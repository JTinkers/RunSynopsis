namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthUserUpdatedNotification
    {
        AuthUser User { get; set; }
    }
}
