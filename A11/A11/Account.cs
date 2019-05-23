using System;

namespace A11
{
    public class Account
    {
        private double Balance { get; set; }

        public Account(double balance)
        {
            if (balance >= 0)
                Balance = balance;
            else
            {
                Balance = 0;
                Console.WriteLine($"Initial balance is invalid. Setting balance to 0.{Environment.NewLine}");
            }
        }

        public void Credit(int amount)
        {
            try
            {
                if (amount < 0)
                    throw new ArgumentException();
                else
                {
                    Balance += amount;
                }
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Credit amount must be positive");
            }
        }

    

    }
}