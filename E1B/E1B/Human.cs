using System;

namespace E1B
{
    public class Human : IHasAge
    {
        public string Name { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Human class constructor passing name and age parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// GetAge method returning the age
        /// </summary>
        /// <returns></returns>
        public int GetAge() => Age;
    }
}