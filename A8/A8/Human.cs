using System;

namespace A8
{
    public class Human
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        double Height { get; set; }

        /// <summary>
        /// Human Class constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        /// <param name="height"></param>
        public Human(string firstName, string lastName, DateTime birthDate, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Height = height;
        }
    }
}