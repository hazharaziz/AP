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



    }


    public class TypeWithMemoryOnHeap
    {
        public static List<TypeOfSize125> objects = new List<TypeOfSize125>();

        public void Allocate()
        {
            for (int i = 0; i < 20000; i++)
            {
                objects.Add(new TypeOfSize125());
            }
        }

        public void DeAllocate()
        {
            objects = null;
        }


    }


    public struct TypeForMaxStackOfDepth10
    {
        TypeOfSize10240 a;
        TypeOfSize10240 b;
        TypeOfSize10240 c;
        TypeOfSize10240 d;
    }

    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize1024 a;
        TypeOfSize1024 b;
        TypeOfSize1024 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
    }

    public struct TypeForMaxStackOfDepth1000
    {
        TypeOfSize125 a;
        TypeOfSize125 b;
        TypeOfSize125 c;
        TypeOfSize125 d;
    }

    public struct TypeForMaxStackOfDepth3000
    {
        TypeOfSize125 a;
    }

    public struct TypeOfSize5
    {
        private byte a;
        private byte b;
        private byte c;
        private byte d;
        private byte e;
    }

    public struct TypeOfSize22
    {
        TypeOfSize5 a;
        TypeOfSize5 b;
        TypeOfSize5 c;
        TypeOfSize5 d;
        private byte e;
        private byte f;
    }

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

    public struct TypeOfSize32768
    {
        TypeOfSize10240 a;
        TypeOfSize10240 b;
        TypeOfSize10240 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
    }

    //public struct TypeOfSize102400
    //{
    //    TypeOfSize10240 a;
    //    TypeOfSize10240 b;
    //    TypeOfSize10240 c;
    //    TypeOfSize10240 d;
    //    TypeOfSize10240 e;
    //    TypeOfSize10240 f;
    //    TypeOfSize10240 g;
    //    TypeOfSize10240 h;
    //    TypeOfSize10240 i;
    //    TypeOfSize10240 j;
    //}
    

}

