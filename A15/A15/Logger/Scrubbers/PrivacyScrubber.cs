using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Logger
{
    /// <summary>
    /// این کلاس مثالی است از پیاده سازی سازگار با
    /// GDPR
    /// https://en.wikipedia.org/wiki/General_Data_Protection_Regulation
    /// 
    /// بصورتی که داده های مشخصه هویت کاربران، تشخیص و حذف شوند.
    /// PII:
    /// https://en.wikipedia.org/wiki/Personally_identifiable_information
    /// 
    /// </summary>
    public class PrivacyScrubber : IPrivacyScrubber
    {
        protected List<IPrivacyScrubber> Scrubbers { get; }

        public PrivacyScrubber(params IPrivacyScrubber[] scrubbers)
        {
            this.Scrubbers = scrubbers.ToList();
        }

        public string Scrub(string content) =>
            this.Scrubbers.Aggregate(content, (c, scrubber) => scrubber.Scrub(c));
    }
}