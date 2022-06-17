namespace RunSynopsis.Domain.Auth.Entities
{
    public class Permission
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public Permission()
        { }

        public Permission(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}