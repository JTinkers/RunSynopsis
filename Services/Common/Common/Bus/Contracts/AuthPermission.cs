namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthPermission
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public AuthPermission(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}