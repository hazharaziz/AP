using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(totalDirectorySize(args[0]));
            Console.ReadKey();
        }


        //Using a global variable
        public static long size = 0; 

        public static long totalDirectorySize(string path)  
        {   
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);



            List<string> directoryContents = new List<string>();

            
            foreach (string dir in dirs)
            {
                directoryContents.Add(dir);
            }

            foreach (string file in files)
            {
                directoryContents.Add(file);
            }



            foreach (string address in directoryContents)
            {
                if (File.Exists(address))
                {
                    FileInfo f = new FileInfo(address);
                    size += f.Length;
                }

                else
                {
                    totalDirectorySize(address);
                }
            }

            return size;
            
        }
        
    }
}
