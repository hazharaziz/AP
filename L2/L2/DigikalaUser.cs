using System;

namespace L2
{
    public class DigikalaUser
    {
        public int Id { get; set; }
        public string FullName { get; set;}
        public double AccountCredit { get; private set; }

        public DigikalaUser(int id, string fullName, double accountCredit)
        {
            Id = id;
            FullName = fullName;
            AccountCredit = accountCredit;
        }

        public bool ExpendCredit(double amount)
        {
            if (amount > AccountCredit)
            {
                return false;
            }
            AccountCredit -= amount;
            return true;
        }

        public void AddUpCredit(double amount)
        {
            AccountCredit += amount;
        }
    }
}