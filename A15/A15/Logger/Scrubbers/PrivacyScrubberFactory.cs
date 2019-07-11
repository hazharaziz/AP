namespace Logger
{
    public static class PrivacyScrubberFactory
    {
        public static IPrivacyScrubber ScrubAll() => new PrivacyScrubber(
                PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                FullNameScrubber.Instance
            );
    }
}