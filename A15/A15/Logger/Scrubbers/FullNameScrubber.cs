using System.Text.RegularExpressions;

namespace Logger
{
    public class FullNameScrubber : AbstractScrubber
    {
        private FullNameScrubber() { }

        private static FullNameScrubber _Instance;

        public static FullNameScrubber Instance => _Instance ?? (_Instance = new FullNameScrubber());

        protected override Regex PIIRegEx => new Regex(@"(Mr.|Mrs.|Miss)\s+[A-Z][a-z]+\s+[A-Z][a-z]+");

        public override string Scrub(string content) => MaskPII(content, this.MaskLetters);
    }
}