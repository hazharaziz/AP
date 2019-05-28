using System;
using System.Collections.Generic;

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


        public AppData(string[] fields)
        {
            //Name = fields[0];
            //Category = fields[1];
            //Rating = fields[2];
            //Reviews = fields[3];
            //Size = fields[4];
            //Installs = fields[5];
            //IsFree = fields[6];
            //Price = fields[7];
            //ContentRating = fields[8];
            //Genres = fields[9];
        }




    }
}