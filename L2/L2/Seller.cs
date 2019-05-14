using System;
using System.Collections.Generic;

namespace L2
{
    public class Seller
    {
        public List<Item> ShopItems { get; set; }
        public string ShopName { get; set; }

        public Seller(string shopName, List<Item> shopItems)
        {
            ShopName = shopName;
            ShopItems = shopItems;
        }

        public int ReleaseNewItem(Item item)
        {
            return 0;

        }




    }
}