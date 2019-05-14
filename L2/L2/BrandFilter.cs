using System;

namespace L2
{
    public class BrandFilter : IFilter
    {
        public string Brand { get; set; }

        public BrandFilter(string brand)
        {
            Brand = brand;
        }

        public bool Filter(Item item) => (item.Brand == Brand);
    }
}