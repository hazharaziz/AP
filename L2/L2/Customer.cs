using System;
using System.Collections.Generic;

namespace L2
{
    public class Customer
    {
        public Cart Cart { get; set; }
        public List<Bill> Bills { get; set; }

        public Customer(Cart cart, List<Bill> bills)
        {
            Cart = cart;
            Bills = bills;
        }

        public void AddToCart(Item item)
        {
            Cart.Items.Add(item);
        }

        public Bill MakeBill()
        {
            return new Bill();
        }

    }
}