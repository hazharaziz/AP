using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S3.Tests
{
    [TestClass()]
    public class ProramTests
    {
        [TestMethod()]
        public void Q1_GetWordsTest()
        {
            string posWordsPath = @"..\..\..\positive.txt";
            string[] expectedList = File.ReadAllLines(posWordsPath,Encoding.UTF8);
            string[] functionList = Program.Q1_GetWords(posWordsPath);
            CollectionAssert.AreEqual(expectedList, functionList);
            
        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {
            string[] words = new string[] { "Hazhar", "Amin", "Sina", "Nima", "Babak", "Saeed", "Puria", "Farhad" };
            bool funcionResult1 = Program.Q2_IsInWords(words, "Ali");
            bool funcionResult2 = Program.Q2_IsInWords(words, "Amin");
            bool funcionResult3 = Program.Q2_IsInWords(words, "Farhad");

            Assert.AreEqual(false, funcionResult1);
            Assert.AreNotEqual(false, funcionResult2);
            Assert.AreEqual(true, funcionResult3);

        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string tweet1 = "this is not the best case in my opinion!";
            string tweet2 = "how are you, my friend?";

            string[] expectedResult1 = new string[] { "this", "is", "not", "the", "best", "case", "in", "my", "opinion" };
            string[] expectedResult2 = new string[] { "how", "are", "you", "my", "friend" };

            string[] functionResult1 = Program.Q3_GetWordsOfTweet(tweet1);
            string[] functionResult2 = Program.Q3_GetWordsOfTweet(tweet2);

            CollectionAssert.AreEqual(expectedResult1, functionResult1);
            CollectionAssert.AreEqual(expectedResult2, functionResult2);
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string[] energeticWords = new string[] { "good", "green", "happy", "grateful","beautiful" };
            string[] negativeWords = new string[] { "bad", "hate", "shameful", "ugly", "frustrating" };

            string sample1 = "This is a beautiful day. I am very happy";
            string sample2 = "He is a bad guy. I hate him so much. Although I am grateful for his help";

            int expectedResult1 = 2;
            int expectedResult2 = -1;

            int functionResult1 = Program.Q4_GetPopChargeOfTweet(sample1, energeticWords, negativeWords);
            int functionResult2 = Program.Q4_GetPopChargeOfTweet(sample2, energeticWords, negativeWords);

            Assert.AreEqual(expectedResult1, functionResult1);
            Assert.AreEqual(expectedResult2,functionResult2);
        

            
        }

        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            string[] tweets = new string[] { "This is a beautiful day. I am very happy" ,
            "He is a bad guy. I hate him so much. Although I am grateful for his help"};

            string[] energeticWords = new string[] { "good", "green", "happy", "grateful", "beautiful" };
            string[] negativeWords = new string[] { "bad", "hate", "shameful", "ugly", "frustrating" };

            double expectedResult = 0.5;
            double functionResult = Program.Q5_GetAvgPopChargeOfTweets(tweets, energeticWords, negativeWords);

            Assert.AreEqual(expectedResult, functionResult);
        }
    }
}