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
            int count = 0;

            foreach (char item in str)
            {
                if (item == '\n')
                {
                    count += 1;
                }
            }
            

            return count;
        }

        public static int FileLineCount(string path)
        {
            char[] tokens = new char[] { '\n' };
            string[] lines = File.ReadAllText(path).Split(tokens,StringSplitOptions.RemoveEmptyEntries);

            int lineCount = lines.Length;

            return lineCount;


        }
        
        public static string[] ListFiles(string path)
        {

            string[] files = Directory.GetFiles(path).ToArray();

            List<string> fileNames = new List<string>();

            List<string> removedFilesNames = new List<string>();

            foreach (string file in files)
            {
                fileNames.Add(file.Split('\\')[file.Split('\\').Length - 1]);
                string removedNameFile = file.Replace(file.Split('\\')[file.Split('\\').Length - 1], "");
                removedFilesNames.Add(removedNameFile);
            }

            string[] splittedName = fileNames[0].Split('0');

            List<string> newFileNames = new List<string>();

            string fileName;
            string secondPart = splittedName[1];
            string completeName;

            List<string> completeFileNames = new List<string>();

            for (int i = 0; i < files.Length; i++)
            {
                fileName = $"{splittedName[0]}{i}{secondPart}";
                completeName = $"{removedFilesNames[i]}{fileName}";
                completeFileNames.Add(completeName);
            }


            return completeFileNames.ToArray();


        }

        public static double FileSize(string path)
        {
            string file = File.ReadAllText(path);
            
            double size = file.Length;
            

            return size;
        }

        
        
    }
}
