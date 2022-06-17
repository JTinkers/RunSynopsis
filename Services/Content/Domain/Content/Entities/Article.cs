namespace RunSynopsis.Domain.Content.Entities
{
    public class Article
    {
        public long Id { get; set; }

        public long AuthorId { get; set; }

        public long CategoryId { get; set; }

        public string HeaderSrc { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Synopsis { get; set; }

        public string Content { get; set; }

        public DateTime WrittenAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
            = new List<Tag>();

        public Article()
        { }

        public Article(
            Author author,
            Category category,
            string headerSrc,
            string title,
            string slug,
            string synopsis,
            string content
        )
        {
            HeaderSrc = headerSrc;
            Title = title;
            Slug = slug;
            Synopsis = synopsis;
            Content = content;
            Author = author;
            AuthorId = author.Id;
            Category = category;
            CategoryId = category.Id;
        }
    }
}