using System.Text.RegularExpressions;

namespace Logger
{
    public class IDScrubber : AbstractScrubber
    {
        private IDScrubber() { }

        private static IDScrubber _Instance;

        public static IDScrubber Instance => _Instance ?? (_Instance = new IDScrubber());

        /// <summary>
        /// Regular expression for ID:
        /// 521-32-1212
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"\(?[0-9]{3}\)?[ -]*[0-9]{2}[ -]*[0-9]{4}");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskNumbers);
    }
}