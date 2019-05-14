using System;

namespace L2
{
    public class PriceFilter : IFilter
    {
        public double PriceBoundary { get; set; }

        public PriceFilter(double priceBoundary)
        {
            PriceBoundary = priceBoundary;
        }

        public bool Filter(Item item) => item.Price < PriceBoundary;    
    }
}