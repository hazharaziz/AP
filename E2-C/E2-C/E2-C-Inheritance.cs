using System;

namespace E2
{
    public abstract class Person
    {

        public virtual string Name { get; set; }
        public bool IsFemale { get; set; }
        public abstract int LunchRate { get; }

        public Person(string name, bool isFemale)
        {
            if (isFemale)
            {
                Name = "خانم " + name;
            }
            else
            {
                Name = "آقای " + name;
            }

            IsFemale = isFemale;
        }
    }

    public class Student : Person
    {
        public Student(string name, bool isFemale) : base(name, isFemale) { }

        public override int LunchRate => 2000;
    }

    public class Employee : Person
    {
        public Employee(string name, bool isFemale) : base(name, isFemale) { }

        public override int LunchRate => 5000;

        public virtual int CalculateSalary(int n)
            => n * 5000;
    }

    public class Teacher : Employee
    {
        public Teacher(string name, bool isFemale)
            : base(name, isFemale)
        {
            Name = "استاد " + name;
            IsFemale = isFemale;
        }
        public override int LunchRate => 10000;
        public override int CalculateSalary(int n)
            => n * 20000;
    }
}