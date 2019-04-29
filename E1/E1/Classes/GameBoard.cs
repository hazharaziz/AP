using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public static List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {   
            List<string> result = new List<string>();

            foreach (IAnimal animal in Animals)
            {
                result.Add(animal.Move(Environment.Air));
                result.Add(animal.Move(Environment.Land));
                result.Add(animal.Move(Environment.Watery));
            }
            
            return result.ToArray();
        }
    }
}