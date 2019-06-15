using System;

namespace E2_C
{
    public class MyString
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
        {
            MyString s3 = new MyString(s2);
            return s1.Str == s3.Str;
        }

        public static bool operator !=(MyString s1, String s2)
            => !(s1 == s2);

        public static MyString operator ++(MyString s1)
        {
            string pascalCase = "";
            foreach (char ch in s1.Str)
            {
                pascalCase += char.ToUpper(ch);
            }
            s1.Str = pascalCase;
            return s1;
        }

        public static MyString operator --(MyString s1)
        {
            string camelCase = "";
            foreach (char ch in s1.Str)
            {
                camelCase += char.ToLower(ch);
            }
            s1.Str = camelCase;
            return s1;
        }

        public override string ToString()
            => Str;

        public override bool Equals(object obj)
        {
            if (obj is MyString)
                return Str == obj.ToString();
            else
                return Str == (string)obj;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public static explicit operator string(MyString v)
        {
            return v.Str;
        }
    }
}