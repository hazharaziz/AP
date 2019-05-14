using System;

namespace L2
{
    public interface IFilter
    {
        bool Filter(Item item);
    }
}