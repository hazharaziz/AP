using System;

namespace A11
{
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        /// <summary>
        /// SavingsAccount Class Constructor
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="interestRate"></param>
        public SavingsAccount(double balance, double interestRate) 
            : base(balance)
        {
            InterestRate = interestRate;
        }

        /// <summary>
        /// CalculateInterest Method for calculating the interest
        /// </summary>
        /// <returns></returns>
        public double CalculateInterest()
            => Balance * InterestRate;
    }
}