namespace RunSynopsis.Domain.Content.Entities
{
    public class Post
    {
        public long Id { get; set; }

        public long AuthorId { get; set; }

        public long CategoryId { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }

        public DateTime WrittenAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Tag> Tags { get; set; }
            = new List<Tag>();

        public Post()
        { }

        public Post(
            Author author,
            Category category,
            string title,
            string slug,
            string content
        )
        {
            Title = title;
            Slug = slug;
            Content = content;
            Author = author;
            AuthorId = author.Id;
            Category = category;
            CategoryId = category.Id;
        }
    }
}