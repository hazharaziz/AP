using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge : IAnimal, IWalkable, IFlyable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double SpeedRate { get; set; }
        public double Health { get; set; }

        /// <summary>
        /// Partridge Class Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="speedRate"></param>
        /// <param name="health"></param>
        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

        /// <summary>
        /// EatFood Method demonstrating eating food for the Partridge
        /// </summary>
        /// <returns></returns>
        public string EatFood() => $"{Name} is a {typeof(Partridge).Name} and is eating";

        /// <summary>
        /// Reproduction Method for checking the reproductivity of the Partridge
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Partridge).Name} and reproductive with {animal.Name}";

        /// <summary>
        /// Move Method talking about the movement abilities of the Partridge
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
                return $"{Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment";
            }
            else
            {
                return Fly();
            }
        }

        /// <summary>
        /// Walk Method talking about the walking ability of the Partridge
        /// </summary>
        /// <returns></returns>
        public string Walk() => $"{Name} is a {typeof(Partridge).Name} and is walking";

        /// <summary>
        /// Fly Method talking about the flying abilities of the Partridge
        /// </summary>
        /// <returns></returns>
        public string Fly() => $"{Name} is a {typeof(Partridge).Name} and is flying";

    }
}