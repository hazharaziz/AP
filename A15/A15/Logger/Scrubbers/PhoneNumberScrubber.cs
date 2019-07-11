using System.Text.RegularExpressions;

namespace Logger
{
    public class PhoneNumberScrubber : AbstractScrubber
    {
        private PhoneNumberScrubber() { }

        private static PhoneNumberScrubber _Instance;

        public static PhoneNumberScrubber Instance => _Instance ?? (_Instance = new PhoneNumberScrubber());

        public override string Scrub(string content) => MaskPII(content, this.MaskNumbers);

        /// <summary>
        /// Regular expression for phone number. E.g., 
        /// (202)332-1212
        /// 202-332-1212
        /// +1 202-332-1212
        /// +98 21 22542323
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"(\+?([0-9]{1,3})[ -]?)?\(?([0-9]{2,3})\)?[ -]*([0-9]{3})[ -]*([0-9]{4,5})");
    }
}