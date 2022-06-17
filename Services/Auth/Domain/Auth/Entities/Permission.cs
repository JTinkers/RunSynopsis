namespace RunSynopsis.Domain.Auth.Entities
{
    public class Permission
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Permission()
        {
        }

        public Permission(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}