using System;
using System.Collections.Generic;

namespace L2
{
    public class ItemInventory
    {
        public List<Item> Items = new List<Item>();

        public ItemInventory() { }

        public List<Item> Filter(List<IFilter> filters)
        {
            List<Item> result = new List<Item>();

            foreach (Item item in Items)
            {
                bool allPassed = true;

                foreach (IFilter filter in filters)
                {
                    if (!filter.Filter(item))
                    {
                        allPassed = false;
                        break;
                    }
                }
                if (allPassed)
                {
                    result.Add(item);
                }
            }

            return result;
        }


        public Item GetItemById(int id)
        {
            Item wanted = null;
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    wanted = item;
                    break;
                }
            }
            return wanted;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        
        public bool RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }
    }
}