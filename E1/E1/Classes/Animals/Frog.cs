using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog : IAnimal, IWalkable, ISwimable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }

        /// <summary>
        /// Frog Class Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="health"></param>
        /// <param name="speedRate"></param>
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        /// <summary>
        /// EatFood Method demonstrating eating food for the frog
        /// </summary>
        /// <returns></returns>
        public string EatFood() => $"{Name} is a {typeof(Frog).Name} and is eating";

        /// <summary>
        /// Reproduction Method for checking the reproductivity of the frog
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Frog).Name} and reproductive with {animal.Name}";

        /// <summary>
        /// Move Method talking about the movement abilities of the frog
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public string Move(Environment env)
        {
            if ((int)env == 0)
            {
                return Walk();
            }
            else if ((int)env == 1)
            {
                return Swim();
            }
            else
            {
                return $"{Name} is a {typeof(Frog).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Air)} environment";
            }
        }

        /// <summary>
        /// Walk Method talking about the walking ability of the frog
        /// </summary>
        /// <returns></returns>
        public string Walk() => $"{Name} is a {typeof(Frog).Name} and is walking";

        /// <summary>
        /// Swim Method for talking about the swimming abilities of the frog
        /// </summary>
        /// <returns></returns>
        public string Swim() => $"{Name} is a {typeof(Frog).Name} and is swimming";
    }
}