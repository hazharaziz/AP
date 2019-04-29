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

        public Crow(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string EatFood() => $"{Name} is a {typeof(Crow).Name} and is eating";

        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Crow).Name} and reproductive with {animal.Name}";

        public string Move(Environment env)
        {
            if ((int)env == 2)
            {
                return $"{Name} is a {typeof(Crow).Name} and is flying";
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

        public string Fly() => $"{Name} is a {typeof(Crow).Name} and is flying";
    }
}