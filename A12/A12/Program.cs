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
            //File.ReadAllLines(@"C:\git\AP97982\A12\A12Tests\googleplaystore.csv")
            //    .Skip(1)
            //    .Select(l =>
            //    {
            //        var regex = new Regex("\"(.*?)\"");
            //        var t = regex.Replace(l, m => m.Value.Replace(',', ' '));
            //        var toks = t.Split(',');
            //        return new
            //        {
            //            App = toks[0],
            //            Category = toks[1],
            //            Rating = double.Parse(toks[2]),
            //            Reviews = int.Parse(toks[3]),
            //            Size = toks[4],
            //            Installs = LongParse(toks[5]),
            //            IsFree = CheckIsFreeOrPaid(toks[6]),
            //            Price = toks[7],
            //            ContentRating = toks[8],
            //            Genres = toks[9],
            //            LastUpdated = DateTime.Parse(toks[10]),
            //            CurrentVer = toks[11],
            //            AndroidVer = toks[12]
            //        };
            //    })
            //    .ToList()
            //    .ForEach(d => Console.WriteLine(d.LastUpdated));

            Console.ReadKey();
        }
    }
}
