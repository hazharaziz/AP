using System;

namespace A11
{
    public class CheckingAccount : Account
    {
        public double TransactionFee { get; set; }

        public CheckingAccount(double balance, double transactionFee)
            : base(balance)
        {
            TransactionFee = transactionFee;
        }

        public void Credit(double amount)
        {
            try
            {
                if (amount < 0)
                    throw new ArgumentException();
                Balance += TransactionFee;
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Credit amount must be positive");
            }            
        }

        public bool Debit(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine($"Debit amount exceeded account balance.{Environment.NewLine}");
                return false;
            }
        }



    }
}