using System;

namespace A11
{
    public class Account
    {
        public double Balance { get; set; }

        /// <summary>
        /// Account Class Constructor
        /// </summary>
        /// <param name="balance"></param>
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

        /// <summary>
        /// Credit Method for increasing the Balance 
        /// </summary>
        /// <param name="amount"></param>
        public void Credit(double amount)
        {
            try
            {
                if (amount < 0)
                    throw new ArgumentException();             
                Balance += amount;
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Credit amount must be positive");
                throw;
            }
        }

        /// <summary>
        /// Debit Method for decreasing the Balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Debit(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Debit amount exceeded account balance.");
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