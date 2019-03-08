using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CalculateLengthTest()
        {
            string str = "This is a test string";
            long expectedLength = 21;
            long functionalLength = Program.CalculateLength(str);
            Assert.AreEqual(expectedLength, functionalLength);
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            string str = "من همیشه سر وقت هستم";
            long expectedChars = 16;
            long functionalChars = Program.LetterCount(str);
            Assert.AreEqual(expectedChars, functionalChars);
        }

        [TestMethod()]
        public void LineCountTest()
        {
            string str = "hello how are you \n" +
                "Is everything Ok \n" +
                "Are you ok? \n" +
                "This is great";
            int expectedLines = 3;
            int functionalLines = Program.LineCount(str);
            Assert.AreEqual(expectedLines, functionalLines);


        }



        [TestMethod()]
        public void FileLineCountTest()
        {
            string path1 = GetTestFile(out int expectedLines1,out int expectedChars1);
            int functionalResult1 = Program.FileLineCount(path1);

            string path2 = GetTestFile(out int expectedLines2, out int expectedChars2);
            int functionalResult2 = Program.FileLineCount(path2);

            Assert.AreEqual(expectedLines1, functionalResult1);
            Assert.AreEqual(expectedLines2, functionalResult2);
        }


        [TestMethod()]
        public void ListFilesTest()
        {
            
            string[] expectedFiles1 = GetTestDir(out string dir1);
            string[] functionalResult1 = Program.ListFiles(dir1);


            string[] expectedFiles2 = GetTestDir(out string dir2);
            string[] functionalResult2 = Program.ListFiles(dir2);
            
            CollectionAssert.AreEqual(expectedFiles1, functionalResult1);
            CollectionAssert.AreEqual(expectedFiles2, functionalResult2);
            

        }

        [TestMethod()]
        public void FileSizeTest()
        {
            string path1 = GetTestFile(out int lineCount1,out int charCount1);
            double expectedSize1 = charCount1;
            double functionalSize1 = Program.FileSize(path1);

            string path2 = GetTestFile(out int lineCount2,out int charCount2);
            double expectedSize2 = charCount2;
            double functionalSize2 = Program.FileSize(path2);

            Assert.AreEqual(expectedSize1, functionalSize1);
            Assert.AreEqual(expectedSize2, functionalSize2);

        }



        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();

            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length + 2;
                lines.Add(line);
            }

            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }

        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
            {
                File.Delete(tmpDir);
            }

            if (!Directory.Exists(tmpDir))
            {
                Directory.CreateDirectory(tmpDir);
            }

            else
            {
                foreach (string file in Directory.GetFiles(tmpDir))
                {
                    File.Delete(file);
                }
            }

            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();

            for (int i = 0; i < rndNum; i++)
            {
                string filename = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(filename, $"file{i}.txt content");
                files.Add(filename);
            }

            return files.ToArray();
        }
        


    }
}