namespace Logger
{
    public interface IPrivacyScrubber
    {
        string Scrub(string content);
    }


    class NullPrivacyScrubber : IPrivacyScrubber
    {
        private static NullPrivacyScrubber _Instance;
        public static NullPrivacyScrubber Instance =>
            _Instance ?? (_Instance = new NullPrivacyScrubber());

        public string Scrub(string content) => content;
    }
}