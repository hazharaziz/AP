using System;

namespace A8
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }

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

        /// <summary>
        /// plus operator method returning a child 
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Human operator+ (Human h1, Human h2)
        {
            Human child = new Human("ChildFirstName", "ChildLastName", DateTime.Today, 30);
            return child;
        }

    }
}