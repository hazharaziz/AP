using System;

namespace L2
{
    public class ReleaseDateFilter : IFilter
    {
        public DateTime PresentTime { get; set; }

        public ReleaseDateFilter(DateTime presentTime)
        {
            PresentTime = presentTime;
        }

        public bool Filter(Item item) => DateTime.Compare(PresentTime, item.ReleaseDate) < 0;
    }
}