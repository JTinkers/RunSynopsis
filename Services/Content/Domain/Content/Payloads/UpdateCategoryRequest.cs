namespace RunSynopsis.Domain.Content.Payloads
{
    public class UpdateCategoryRequest
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}