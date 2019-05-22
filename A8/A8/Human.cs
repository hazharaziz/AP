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

        /// <summary>
        /// less than operator overloading for comparing humans' ages 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator <(Human h1, Human h2)
        {
            return DateTime.Compare(h2.BirthDate, h1.BirthDate) < 0;
        }

        /// <summary>
        /// greater than operator overloading for comparing humans' ages 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator >(Human h1, Human h2)
        {
            return !(h1 < h2);
        }

        /// <summary>
        /// less than or equal operator oveerloading for comparing humans' ages 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator <=(Human h1, Human h2)
        {
            return DateTime.Compare(h1.BirthDate, h2.BirthDate) >= 0;
        }

        /// <summary>
        /// greater than or equal operator oveerloading for comapraing humans' ages 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator >=(Human h1, Human h2)
        {
            return !(h1 <= h2);
            //return DateTime.Compare(h1.BirthDate, h2.BirthDate) <= 0;
        }

        /// <summary>
        /// comparing the equality of ages
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator ==(Human h1, Human h2)
        {
            return DateTime.Compare(h1.BirthDate, h2.BirthDate) == 0;
        }

        /// <summary>
        /// comparing the unequality of ages 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator !=(Human h1, Human h2)
        {
            return !(h1 == h2);
        }

        /// <summary>
        /// Equals method overrided for checking the equality of the properties of two Humans
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                Human h = (Human)obj;
                return (FirstName == h.FirstName && LastName == h.LastName
                    && BirthDate == h.BirthDate && Height == h.Height);
            }
        }

        /// <summary>
        /// GetHashCode method overriden for returning an integration of the properties' hashcodes
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return  (FirstName.GetHashCode() | LastName.GetHashCode() |
                BirthDate.GetHashCode() | Height.GetHashCode());
        }


    }
}