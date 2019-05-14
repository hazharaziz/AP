using System;

namespace L2
{
    public class PriceRangeFilter : IFilter
    {
        public double TopRange { get; set; }
        public double LowRange { get; set; }

        public PriceRangeFilter(double lowRange, double topRange)
        {
            TopRange = topRange;
            LowRange = lowRange;
        }

        public bool Filter(Item item) => (item.Price > LowRange && item.Price < TopRange);
    }
}