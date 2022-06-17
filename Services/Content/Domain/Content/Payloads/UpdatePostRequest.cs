namespace RunSynopsis.Domain.Content.Payloads
{
    public class UpdatePostRequest
    {
        public long Id { get; set; }

        public long? CategoryId { get; set; }

        public IEnumerable<long>? TagIds { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }
    }
}