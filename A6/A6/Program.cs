using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        /// <summary>
        /// returning an integer according to the type of the object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectType(object o)
        {
            if (o is string)
            {
                return 0;
            }
            else if (o is int[])
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// checks if the future husband is ideal or not
        /// </summary>
        /// <param name="fht"></param>
        /// <returns></returns>
        public static bool IdealHusband(FutureHusbandType fht) =>
            ((int)fht == 6) || ((int)fht == 3) || ((int)fht == 5);
    }

    /// <summary>
    /// an enum describing the adjectives of the future husband
    /// </summary>
    public enum FutureHusbandType : int
    {
        None = 0,
        HasBigNose = 1,
        IsBald = 2,
        IsShort = 4
    }

    public struct StructOrClass3
    {
        public StructOrClass2 X { get; set; }
    }

    public class StructOrClass2
    {
        public int X { get; set; }
    }

    public struct StructOrClass1
    {
        public int X { get; set; }
    }

    // a reference type for allocating and deallocating the heap
    public class TypeWithMemoryOnHeap
    {
        public static List<TypeOfSize125> objects = new List<TypeOfSize125>();

        /// <summary>
        /// method for allocating the heap
        /// </summary>
        public void Allocate()
        {
            for (int i = 0; i < 20000; i++)
            {
                objects.Add(new TypeOfSize125());
            }
        }

        /// <summary>
        /// method for deallocating the heap
        /// </summary>
        public void DeAllocate()
        {
            objects = null;
        }
    }

    /// <summary>
    /// value type that takes up the entire memory space by 10 times invoking it
    /// </summary>
    public struct TypeForMaxStackOfDepth10
    {
        TypeOfSize10240 a;
        TypeOfSize10240 b;
        TypeOfSize10240 c;
        TypeOfSize10240 d;
    }

    /// <summary>
    /// value type that takes up the entire memory space by 100 times invoking it
    /// </summary>
    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize1024 a;
        TypeOfSize1024 b;
        TypeOfSize1024 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
    }

    /// <summary>
    /// value type that takes up the entire memory space by 1000 times invoking it
    /// </summary>
    public struct TypeForMaxStackOfDepth1000
    {
        TypeOfSize125 a;
        TypeOfSize125 b;
        TypeOfSize125 c;
        TypeOfSize125 d;
    }

    /// <summary>
    /// value type that takes up the entire memory space by 3000 times invoking it
    /// </summary>
    public struct TypeForMaxStackOfDepth3000
    {
        TypeOfSize125 a;
    }

    /// <summary>
    /// value type of 5 bytes
    /// </summary>
    public struct TypeOfSize5
    {
        private byte a;
        private byte b;
        private byte c;
        private byte d;
        private byte e;
    }

    /// <summary>
    /// value type of 22 bytes
    /// </summary>
    public struct TypeOfSize22
    {
        TypeOfSize5 a;
        TypeOfSize5 b;
        TypeOfSize5 c;
        TypeOfSize5 d;
        private byte e;
        private byte f;
    }

    /// <summary>
    /// value type of 125 bytes
    /// </summary>
    public struct TypeOfSize125
    {
        TypeOfSize22 a;
        TypeOfSize22 b;
        TypeOfSize22 c;
        TypeOfSize22 d;
        TypeOfSize22 e;
        TypeOfSize5 f;
        TypeOfSize5 g;
        TypeOfSize5 h;
    }

    /// <summary>
    /// value type of 1024 bytes
    /// </summary>
    public struct TypeOfSize1024
    {
        TypeOfSize125 a;
        TypeOfSize125 b;
        TypeOfSize125 c;
        TypeOfSize125 d;
        TypeOfSize125 e;
        TypeOfSize125 f;
        TypeOfSize125 g;
        TypeOfSize125 h;
        TypeOfSize22 i;
        private byte j;
        private byte k;
    }

    /// <summary>
    /// value type of 10240 bytes
    /// </summary>
    public struct TypeOfSize10240
    {
        TypeOfSize1024 a;
        TypeOfSize1024 b;
        TypeOfSize1024 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
        TypeOfSize1024 f;
        TypeOfSize1024 g;
        TypeOfSize1024 h;
        TypeOfSize1024 i;
        TypeOfSize1024 j;
    }

    /// <summary>
    /// value type of 32768 bytes
    /// </summary>
    public struct TypeOfSize32768
    {
        TypeOfSize10240 a;
        TypeOfSize10240 b;
        TypeOfSize10240 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
    }
}

