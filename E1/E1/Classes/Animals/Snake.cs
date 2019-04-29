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

        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }


        public string Crawl() => $"{Name} is a {typeof(Snake).Name} and is crawling";

        public string EatFood() => $"{Name} is a {typeof(Snake).Name} and is eating";

        public string Move(Environment env)
        {
            if ((int)env == 0)
            {
                return $"{Name} is a {typeof(Snake).Name} and is crawling";
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

        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Snake).Name} and reproductive with {animal.Name}";
    }
}