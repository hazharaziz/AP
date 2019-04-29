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

        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string EatFood() => $"{Name} is a {typeof(Frog).Name} and is eating";

        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Frog).Name} and reproductive with {animal.Name}";

        public string Move(Environment env)
        {
            if ((int)env == 0)
            {
                return $"{Name} is a {typeof(Frog).Name} and is walking";
            }
            else if ((int)env == 1)
            {
                return $"{Name} is a {typeof(Frog).Name} and is swimming";
            }
            else
            {
                return $"{Name} is a {typeof(Frog).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Air)} environment";
            }
        }
        public string Walk() => $"{Name} is a {typeof(Frog).Name} and is walking";

        public string Swim() => $"{Name} is a {typeof(Frog).Name} and is swimming";
    }
}