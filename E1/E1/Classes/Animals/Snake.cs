using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Snake : IAnimal, ICrawlable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }

        /// <summary>
        /// Snake Class Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="health"></param>
        /// <param name="speedRate"></param>
        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        /// <summary>
        /// EatFood Method demonstrating eating food for the Snake
        /// </summary>
        /// <returns></returns>
        public string EatFood() => $"{Name} is a {typeof(Snake).Name} and is eating";

        /// <summary>
        /// Reproduction Method for checking the reproductivity of the Snake
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Snake).Name} and reproductive with {animal.Name}";

        /// <summary>
        /// Move Method talking about the movement abilities of the Snake
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public string Move(Environment env)
        {
            if ((int)env == 0)
            {
                return Crawl();
            }
            else if ((int)env == 1)
            {
                return $"{Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment";
            }
            else
            {
                return $"{Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Air)} environment";
            }
        }

        /// <summary>
        /// Crawl Method talking about the Crawling abilities of the Snake
        /// </summary>
        /// <returns></returns>
        public string Crawl() => $"{Name} is a {typeof(Snake).Name} and is crawling";
    }
}