using System;

namespace A11
{
    public class SavingsAccount : Account
    {
        public double Interest { get; set; }

        public SavingsAccount(double balance, double interest) 
            : base(balance)
        {
            Interest = interest;
        }

        public double CalculateInterest()
            => Balance - Interest;
    }
}