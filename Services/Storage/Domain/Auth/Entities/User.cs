namespace RunSynopsis.Domain.Auth.Entities
{
    public class User
    {
        public long Id { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

        public IEnumerable<Permission> Permissions { get; set; } = Enumerable.Empty<Permission>();
    }
}