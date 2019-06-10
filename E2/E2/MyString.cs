using System;

namespace E2.Tests
{
    public class MyString
    {
        private string Str;

        public MyString(string str)
        {
            Str = str;
        }

        public static explicit operator MyString(string v)
        {
            return new MyString(v);
        }

    }
}