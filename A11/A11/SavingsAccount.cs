using System;

namespace A11
{
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(double balance, double interestRate) 
            : base(balance)
        {
            InterestRate = interestRate;
        }

        public double CalculateInterest()
            => Balance - InterestRate;
    }
}