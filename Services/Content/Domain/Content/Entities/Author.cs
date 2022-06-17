namespace RunSynopsis.Domain.Content.Entities
{
    public class Author
    {
        public long Id { get; set; }

        public string Nickname { get; set; }

        public string? Bio { get; set; }

        public Uri? AvatarUrl { get; set; }

        public Uri? HomepageUrl { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
            = new List<Article>();

        public virtual ICollection<Post> Posts { get; set; }
            = new List<Post>();
    }
}