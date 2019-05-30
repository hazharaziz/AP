using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace A12
{
    public class Program
    {
        static void Main(string[] args)
        {
            var today = new DateTime(2019, 5, 27);
            var a = File.ReadAllLines(@"C:\git\AP97982\A12\A12Tests\googleplaystore.csv")
                .Skip(1)
                //.Take(20)
                .Select(l =>
                {
                    var regex = new Regex("\"(.*?)\"");
                    var t = regex.Replace(l, m => m.Value.Replace(',', ' '));
                    var toks = t.Split(',');
                    return new
                    {
                        App = toks[0],
                        Category = toks[1],
                        Rating = double.Parse(toks[2]),
                        Reviews = int.Parse(toks[3]),
                        Size = toks[4],
                        Installs = LongParse(toks[5]),
                        IsFree = CheckIsFreeOrPaid(toks[6]),
                        Price = toks[7],
                        ContentRating = toks[8],
                        Genres = toks[9],
                        LastUpdated = DateTime.Parse(toks[10]),
                        CurrentVer = toks[11],
                        AndroidVer = toks[12]
                    };
                })
                .GroupBy(d => d.Category)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key).First();
            //.OrderByDescending(d => d.Installs)
            //.OrderByDescending(d => d.Price)
            //.Select(g => $"{g.App}")
            //.Take(4)
            //.ToList()
            //.ForEach(l => Console.WriteLine(l));

            Console.WriteLine(a);

            Console.ReadKey();
        }



        /// <summary>
        /// RatingParse Method for checking the rating of the app
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static double RatingParse(string v)
        {
            if (v.Contains("NaN"))
                return 0;
            else
                return double.Parse(v);
        }

        /// <summary>
        /// CheckPrice Method for checking the price of the app
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static double CheckPrice(string v)
        {
            if (v.Contains('$'))
                return double.Parse(v.Substring(1));
            else
                return double.Parse(v);
        }

        /// <summary>
        /// SizeParse Method for checking the size of the app
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static double SizeParse(string v)
        {
            if (v.Contains("M"))
                return DoubleParse(v) * Math.Pow(10, 6);
            else if (v.Contains("k"))
                return DoubleParse(v) * Math.Pow(10, 3);
            else
                return 0;
        }

        /// <summary>
        /// CheckIsFreeOrPaid Method for checking if the app is free or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long CheckIsFreeOrPaid(string str)
        {
            if (str == "Free")
                return 0;
            else
                return 1;
        }

        /// <summary>
        /// DoubleParse Method for parsing the strings into doubles
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double DoubleParse(string str)
        {
            string result = "0";
            str.Where(x => char.IsDigit(x)).ToList()
                .ForEach(d => result += d);
            return double.Parse(result);
        }

        /// <summary>
        /// LongParse Method for parsing the strings into longs
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static long LongParse(string str)
        {
            var result = "";
            str.Where(d => char.IsDigit(d)).ToList()
                .ForEach(x => result += x);
            return long.Parse(result);
        }

    }
}
