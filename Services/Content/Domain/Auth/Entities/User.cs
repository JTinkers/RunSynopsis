namespace RunSynopsis.Domain.Auth.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Nickname { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

        public Uri? AvatarUrl { get; set; }

        public string? Bio { get; set; }

        public Uri? Homepage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastSeenAt { get; set; }

        public IEnumerable<Permission> Permissions { get; set; }
    }
}