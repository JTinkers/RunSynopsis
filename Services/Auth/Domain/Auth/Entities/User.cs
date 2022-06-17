namespace RunSynopsis.Domain.Auth.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Nickname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public string? Bio { get; set; }

        public Uri? HomepageUrl { get; set; }

        public Uri? AvatarUrl { get; set; }

        public bool IsVerified { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastSeenAt { get; set; }

        public bool IsBanned => ReceivedBans.Any(x => !x.IsExpired);

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public virtual ICollection<Ban> ReceivedBans { get; set; } = new List<Ban>();

        public virtual ICollection<Ban> GivenBans { get; set; } = new List<Ban>();

        public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();

        public User()
        {
        }

        public User(
            string nickname,
            string username,
            string password,
            string mail,
            Uri avatarUrl)
        {
            Nickname = nickname;
            Username = username;
            Password = password;
            Mail = mail;
            AvatarUrl = avatarUrl;
        }
    }
}