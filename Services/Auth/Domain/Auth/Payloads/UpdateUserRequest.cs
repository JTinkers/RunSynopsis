namespace RunSynopsis.Domain.Auth.Payloads
{
    public class UpdateUserRequest
    {
        public string? Bio { get; set; }

        public string? Password { get; set; }

        public Uri? HomepageUrl { get; set; }

        public Uri? AvatarUrl { get; set; }
    }
}