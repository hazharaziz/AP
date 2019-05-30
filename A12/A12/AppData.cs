using System;
using System.Collections.Generic;
using System.Linq;

namespace A12
{
    public class AppData
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
        public long Reviews { get; set; }
        public double Size { get; set; }
        public long Installs { get; set; }
        public long IsFree { get; set; }
        public double Price { get; set; }
        public string ContentRating { get; set; }
        public List<string> Genres { get; set; }
        public DateTime LastUpdate { get; set; }
        public string CurrentVersion { get; set; }
        public string AndroidVersion { get; set; }

        /// <summary>
        /// AppData Class Constructor
        /// </summary>
        /// <param name="fields"></param>
        public AppData(string[] fields)
        {
            Name = fields[0];
            Category = fields[1];
            Rating = RatingParse(fields[2]);
            Reviews = long.Parse(fields[3]);
            Size = SizeParse(fields[4]);
            Installs = LongParse(fields[5]);
            IsFree = CheckIsFree(fields[6]);
            Price = CheckPrice(fields[7]);
            ContentRating = fields[8];
            Genres = fields[9].Split('&').ToList();
            LastUpdate = DateTime.Parse(fields[10]);
            CurrentVersion = fields[11];
            AndroidVersion = fields[12];
        }

        /// <summary>
        /// RatingParse Method for checking the rating of the app
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private double RatingParse(string v)
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
        public double CheckPrice(string v)
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
        private double SizeParse(string v)
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
        public long CheckIsFree(string str)
        {
            if (str == "Free")
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// DoubleParse Method for parsing the strings into doubles
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public double DoubleParse(string str)
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
        public long LongParse(string str)
        {
            var result = "";
            str.Where(d => char.IsDigit(d)).ToList()
                .ForEach(x => result += x);
            return long.Parse(result);
        }
    }
}