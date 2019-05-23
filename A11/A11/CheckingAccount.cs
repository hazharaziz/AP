using System;

namespace A11
{
    public class CheckingAccount : Account
    {
        public double TransactionFee { get; set; }

        /// <summary>
        /// CheckingAccount Class Constructor
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="transactionFee"></param>
        public CheckingAccount(double balance, double transactionFee)
            : base(balance)
        {
            TransactionFee = transactionFee;
        }

        /// <summary>
        /// Credit Method for increasing the Balance according to the transaction fee
        /// </summary>
        /// <param name="amount"></param>
        public void Credit(double amount)
        {
            try
            {
                if (amount < 0)
                    throw new ArgumentException();
                Balance += (amount - TransactionFee);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Credit amount must be positive");
                throw;
            }            
        }

        /// <summary>
        /// Debit Method for decreasing the Balance according to the transaction fee
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Debit(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= (amount + TransactionFee);
                return true;
            }
            else
            {
                Console.WriteLine($"Debit amount exceeded account balance.");
                return false;
            }
        }



    }
}