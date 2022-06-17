namespace RunSynopsis.Domain.Storage.Entities
{
    public class Storable
    {
        public string Hash { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Extension { get; set; }

        public string? Subdirectory { get; set; }

        public long? UserId { get; set; }

        public DateTime StoredAt { get; set; } = DateTime.UtcNow;

        public Storable()
        { }

        public Storable(string name, string extension, string? subdirectory, long? userId = null)
        {
            Name = name;
            Extension = extension;
            Subdirectory = subdirectory;
            UserId = userId;
        }
    }
}