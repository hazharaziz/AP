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
        public override void Credit(double amount)
        {
            Balance -= TransactionFee;
            base.Credit(amount);
        }

        /// <summary>
        /// Debit Method for decreasing the Balance according to the transaction fee
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool Debit(double amount)
        {
            if (amount <= Balance)
                Balance -= TransactionFee;
            return base.Debit(amount);
        }



    }
}