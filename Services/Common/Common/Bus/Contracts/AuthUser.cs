namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthUser
    {
        public long Id { get; set; }

        public string Nickname { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

        public string? Bio { get; set; }

        public Uri? AvatarUrl { get; set; }

        public Uri? HomepageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastSeenAt { get; set; }

        public IEnumerable<AuthPermission> Permissions { get; set; } = new List<AuthPermission>();
    }
}