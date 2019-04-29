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

        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

        public string EatFood() => $"{Name} is a {typeof(Partridge).Name} and is eating";

        public string Reproduction(IAnimal animal) => $"{Name} is a {typeof(Partridge).Name} and reproductive with {animal.Name}";

        public string Move(Environment env)
        {
            if ((int)env == 0)
            {
                return $"{Name} is a {typeof(Partridge).Name} and is walking";
            }
            else if ((int)env == 1)
            {
                return $"{Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment";
            }
            else
            {
                return $"{Name} is a {typeof(Partridge).Name} and is flying";
            }
        }

        public string Walk() => $"{Name} is a {typeof(Partridge).Name} and is walking";

        public string Fly() => $"{Name} is a {typeof(Partridge).Name} and is flying";

    }
}