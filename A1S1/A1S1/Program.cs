using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\git\AP97982\A1S3\A1S3\TwitterData\Words\negative.txt";
            Console.WriteLine(FileSize(path));



            Console.ReadKey();
        }

        public static long CalculateLength(string str)
        {
            long stringLength = str.Length;

            return stringLength;
        }

        public static long LetterCount(string str)
        {
            long count = 0;

            foreach (char item in str)
            {
                if (Char.IsLetter(item) == true)
                {
                    count += 1;
                }
            }

            return count;
        }

        public static int LineCount(string str)
        {
            int lineCount = 0;

            foreach (char item in str)
            {
                if (item == '\n')
                {
                    lineCount += 1;
                }
            }
            

            return lineCount;
        }

        public static int FileLineCount(string path)
        {
            char[] tokens = new char[] { '\n' };
            string[] lines = File.ReadAllText(path).Split(tokens,StringSplitOptions.RemoveEmptyEntries);

            int lineCount = lines.Length;

            return lineCount;
        }

        
        public static string[] ListFiles(string path) => Directory.GetFiles(path);
        
        public static double FileSize(string path)
        {
            string fileContent = File.ReadAllText(path);
            
            double size = fileContent.Length;
           
            return size;
        }

        
        
    }
}
