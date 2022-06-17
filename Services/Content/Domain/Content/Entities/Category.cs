namespace RunSynopsis.Domain.Content.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Category()
        { }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}