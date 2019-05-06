using System;
using A8;

namespace HumanTests
{
    public class TestData
    {
        //BirthDates
        public static DateTime d1 = new DateTime(1991, 3, 6);
        public static DateTime d2 = new DateTime(1992, 4, 10);
        public static DateTime d3 = new DateTime(1990, 7, 11);
        public static DateTime d4 = new DateTime(1997, 1, 19);
        public static DateTime d5 = new DateTime(1995, 5, 28);
        public static DateTime d6 = new DateTime(1996, 9, 2);

        //Humans 
        public static Human Jack = new Human("Jack", "Smith", d1, 189);
        public static Human John = new Human("John", "Williams", d2, 182);
        public static Human Liam = new Human("Laim", "Jones", d3, 173);
        public static Human Ava = new Human("Ava", "Smith", d4, 181); 
        public static Human Emma = new Human("Jack", "Williams", d5, 174);
        public static Human Amelia = new Human("Jack", "Jones", d6, 179);
        public static Human Harry = Jack + Ava;
        public static Human Oscar = John + Emma;
        public static Human James = Liam + Amelia;
    }

}
