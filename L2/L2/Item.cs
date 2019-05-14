using System;

namespace L2
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; private set; }
        public DateTime ReleaseDate { get; set; }
        public string Brand { get; set; }
        public string Seller { get; set; }

        public Item(string title, double price, DateTime releaseDate, string brand, string seller, int id = 0)
        {
            Title = title;
            Price = price;
            ReleaseDate = releaseDate;
            Brand = brand;
            Seller = seller;
            Id = id;
        }

        public double UpdatePrice(double newPrice)
        {
            if (newPrice <= (1.2 * Price))
            {
                Price = newPrice;
                return newPrice;
            }
            Price = newPrice;
            return (1.2 * Price);
        }

        public void AddToCart(Customer customer)
        {
            
        }


        
    }
}