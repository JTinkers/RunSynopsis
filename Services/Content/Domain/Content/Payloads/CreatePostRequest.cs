namespace RunSynopsis.Domain.Content.Payloads
{
    public class CreatePostRequest
    {
        public long CategoryId { get; set; }

        public IEnumerable<long> TagIds { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}