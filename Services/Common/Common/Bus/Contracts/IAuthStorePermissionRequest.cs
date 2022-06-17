namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IAuthStorePermissionRequest
    {
        AuthPermission Permission { get; set; }
    }
}