using System;

namespace E2.Tests
{
    public class MyString : IEquatable
    {
        public string Str { get; set; }

        public MyString(string str)
        {
            Str = str;
        }

        public static explicit operator MyString(string v)
        {
            return new MyString(v);
        }

        public static bool operator ==(MyString s1, String s2)
            => s1.Equals(s2);

        public static bool operator !=(MyString s1, String s2)
            => !(s1 == s2);

        public static MyString operator ++(MyString s1)
        {
            
            string pascalCase = "";
            foreach (char ch in s1.Str)
            {
                pascalCase += char.ToUpper(ch);
            }
            return new MyString(pascalCase);
        }

        public static MyString operator --(MyString s1)
        {

            string camelCase = "";
            foreach (char ch in s1.Str)
            {
                camelCase += char.ToLower(ch);
            }
            return new MyString(camelCase);
        }

        public override string ToString()
            => Str;

        public override bool Equals(object obj)
            => Str == obj;

        public override int GetHashCode()
            => base.GetHashCode();

        public static explicit operator string(MyString v)
        {
            return v.Str;
        }
    }
}