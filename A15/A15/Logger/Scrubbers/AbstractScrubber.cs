using System.Linq;
using System.Text.RegularExpressions;

namespace Logger
{
    public abstract class AbstractScrubber : IPrivacyScrubber
    {
        public abstract string Scrub(string content);

        protected abstract Regex PIIRegEx { get; }

        protected MatchEvaluator MaskNumbers = m => new string(
            m.Value.Select(c => char.IsDigit(c) ? 'X' : c).ToArray());

        protected MatchEvaluator MaskLetters = m => new string(
            m.Value.Select(c => !char.IsLetter(c) ? c : char.IsUpper(c) ? 'X' : 'x').ToArray());

        protected string MaskPII(string content, MatchEvaluator maskFn) 
            => PIIRegEx.Replace(content, maskFn);

    }
}