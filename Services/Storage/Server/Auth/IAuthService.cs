namespace RunSynopsis.Server.Auth
{
    internal interface IAuthService
    {
        Task StorePermissionAsync<TEnum>(TEnum permission) where TEnum : Enum;
    }
}