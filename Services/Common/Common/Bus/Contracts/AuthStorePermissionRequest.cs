namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthStorePermissionRequest : IAuthStorePermissionRequest
    {
        public AuthPermission Permission { get; set; }

        public AuthStorePermissionRequest(AuthPermission permission)
        {
            Permission = permission;
        }
    }
}