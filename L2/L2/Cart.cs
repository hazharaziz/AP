using System.Collections.Generic;
using System;

namespace L2
{
    public class Cart
    {
        public List<Item> Items { get; set; }
        public Customer Owner { get; set; }
        public double TotalAmount { get; set; }

        public Cart(Customer owner, List<Item> items, double totalAmount)
        {
            Items = items;
            Owner = owner;
            TotalAmount = TotalAmount;
        }

        public Bill Finalize()
        {
            return new Bill();
        }
        
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public bool RemoveItem(int id)
        {
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    Items.Remove(item);
                }
            }
            return true;
        }
    }
}