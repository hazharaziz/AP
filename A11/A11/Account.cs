using System;

namespace A11
{
    public class Account
    {
        public double Balance { get; set; }

        public Account(double balance)
        {
            if (balance >= 0)
                Balance = balance;
            else
            {
                Balance = 0;
                Console.WriteLine("Initial balance is invalid. Setting balance to 0.");
            }
        }

        public void Credit(double amount)
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

        public bool Debit(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine($"Debit amount exceeded account balance.{Environment.NewLine}");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

    

    }
}