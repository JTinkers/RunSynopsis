namespace RunSynopsis.Domain.Auth.Entities
{
    public class User
    {
        public long Id { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

        public IEnumerable<Permission> Permissions { get; set; }

        public User()
        { }

        public bool HasPermission(string type, string value)
        {
            return Permissions.Any(x => x.Type == type
                && x.Value == value);
        }

        public bool HasPermission(Permission permission)
            => HasPermission(permission.Type, permission.Value);

        public bool HasPermission<TEnum>(TEnum value) where TEnum : Enum
        {
            var permission = new Permission(typeof(TEnum).Name, value.ToString());

            return HasPermission(permission);
        }
    }
}