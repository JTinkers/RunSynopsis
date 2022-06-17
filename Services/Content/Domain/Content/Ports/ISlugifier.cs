namespace RunSynopsis.Domain.Content.Ports
{
    internal interface ISlugifier
    {
        public string Make(string input);
    }
}