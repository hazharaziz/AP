using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            string[] files = Directory.GetFiles(@"..\..\TwitterData\Tweets");

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            files = Directory.GetFiles(@"..\..\TwitterData\Words");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            
            
            string filesPath = @"C:\git\AP97982\A1S3\A1S3\TwitterData\Tweets";
            string[] textfiles = Directory.GetFiles(filesPath);

            string resultTextPath = @"C:\git\AP97982\A1S3\A1S3\result.txt";
            string posWordsPath = @"C:\git\AP97982\A1S3\A1S3\TwitterData\Words\positive.txt";
            string negWordsPath = @"C:\git\AP97982\A1S3\A1S3\TwitterData\Words\negative.txt";

            string filename;
            string[] posWords = Q1_GetWords(posWordsPath);
            string[] negWords = Q1_GetWords(negWordsPath);
            double avgCharge = 0;
            string[] lines; 
            string content;
            List<string> contents = new List<string>();


            foreach (string file in textfiles)
            {
                filename = Path.GetFileName(file);

                lines = File.ReadAllLines(file);
                string[] tweets = new string[lines.Length - 1];
                
                for (int i = 1; i < lines.Length; i++)
                {
                    tweets[i - 1] = lines[i];
                }
                

                avgCharge = Q5_GetAvgPopChargeOfTweets(tweets, posWords, negWords);
                content = $"{filename} : {avgCharge.ToString("0.000")}";
                contents.Add(content);
            }

            File.WriteAllLines(resultTextPath, contents);
            

            
            Console.ReadKey();
        }

        public static string[] Q1_GetWords(string path)
        {
            string[] words = File.ReadAllLines(path,Encoding.UTF8);

            return words;

        }

        public static bool Q2_IsInWords(string[] words, string word)
        {
            if (words.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            char[] tokens = new char[] { ' ', '\'', '\"', '@', '?', '!', ',','.','/',';','_',':','؟','،','(',')','/','-' };
            string[] words = tweet.Split(tokens,StringSplitOptions.RemoveEmptyEntries);

            return words;

        }

        public static int Q4_GetPopChargeOfTweet(string tweetString, string[] posWords, string[] negWords)
        {
            int posCharge = 0;
            int negCharge = 0;

            foreach (string posWord in posWords)
            {
                if (tweetString.Contains(posWord))
                {
                    posCharge += 1;
                }
                
            }

            foreach (string negWord in negWords)
            {
                if (tweetString.Contains(negWord))
                {
                    negCharge += -1;
                }
            }

            int finalCharge = posCharge + negCharge;

            return finalCharge;
        }

        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] posWords, string[] negWords)
        {
            List<double> charges = new List<double>();

            foreach (string tweet in tweets)
            {
                double tweetCharge = Q4_GetPopChargeOfTweet(tweet, posWords, negWords);
                charges.Add(tweetCharge);
            }

            double AverageCharge = charges.Sum() / charges.Count;

            return AverageCharge;
        }




    }
}
