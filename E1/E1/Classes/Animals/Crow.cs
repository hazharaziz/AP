using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow : IAnimal, IFlyable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }


        /// <summary>
        /// Crow Class Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="health"></param>
        /// <param name="speedRate"></param>
        public Crow(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        /// <summary>
        /// EatFood Method demonstrating eating food for the Crow
        /// </summary>
        /// <returns></returns>
        public string EatFood() => $"{Name} is a {typeof(Crow).Name} and is eating";

        /// <summary>
        /// Reproduction Method for checking the reproductivity of the Crow
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Crow).Name} and reproductive with {animal.Name}";

        /// <summary>
        /// Move Method talking about the movement abilities of the Crow
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public string Move(Environment env)
        {
            if ((int)env == 2)
            {
                return Fly();
            }
            else if ((int)env == 0)
            {
                return $"{Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Land)} environment";
            }
            else
            {
                return $"{Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment";
            }

        }

        /// <summary>
        /// Fly Method talking about the flying abilities of the Crow
        /// </summary>
        /// <returns></returns>
        public string Fly() => $"{Name} is a {typeof(Crow).Name} and is flying";
    }
}