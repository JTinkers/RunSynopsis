namespace RunSynopsis.Domain.Content.Payloads
{
    public class UpdateArticleRequest
    {
        public long Id { get; set; }

        public long? CategoryId { get; set; }

        public IEnumerable<long>? TagIds { get; set; }

        public string? HeaderSrc { get; set; }

        public string? Title { get; set; }

        public string? Synopsis { get; set; }

        public string? Content { get; set; }
    }
}