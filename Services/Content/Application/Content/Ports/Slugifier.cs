using RunSynopsis.Domain.Content.Ports;
using System.Text.RegularExpressions;

namespace RunSynopsis.Application.Content.Ports
{
    public class Slugifier : ISlugifier
    {
        private const string SEPARATOR = "-";

        private readonly Regex patternNonAlphanumerics;

        private readonly Regex patternSpaces;

        public Slugifier()
        {
            patternNonAlphanumerics = new Regex(@"[^A-Za-z0-9\s-]");
            patternSpaces = new Regex(@"\s+");
        }

        public string Make(string input)
        {
            input = input.ToLower();
            input = patternNonAlphanumerics.Replace(input, "");
            input = patternSpaces.Replace(input, " ");
            input = patternSpaces.Replace(input, SEPARATOR);

            return input;
        }
    }
}