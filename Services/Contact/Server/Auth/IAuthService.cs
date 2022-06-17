namespace RunSynopsis.Server.Auth
{
    public interface IAuthService
    {
        Task StorePermissionAsync<TEnum>(TEnum permission) where TEnum : Enum;
    }
}