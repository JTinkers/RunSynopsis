namespace RunSynopsis.Domain.Content.Entities
{
    public class Tag
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
            = new HashSet<Article>();

        public virtual ICollection<Post> Posts { get; set; }
            = new HashSet<Post>();

        public Tag()
        { }

        public Tag(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}