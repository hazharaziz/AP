using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace A12
{
    public class AppAnalysis
    {

        public List<AppData> Apps = new List<AppData>();

        private AppAnalysis() { }

        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
            AppAnalysis appAnalysis = new AppAnalysis();

            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    appAnalysis.AppenApp(fields);
                }
            }

            //File.ReadAllLines(csvAddress)
            //    .Skip(1)
            //    .Select(l =>
            //    {
            //        var regex = new Regex("\"(.*?)\"");
            //        var newLine = regex.Replace(l, m => m.Value.Replace(',', ' '));
            //        var fields = newLine.Split(',');
            //        return fields;
            //    })
            //    .ToList()
            //    .ForEach(fields => appAnalysis.AppenApp(fields));

            return appAnalysis;
        }

        public void AppenApp(string[] fields)
        {
            AppData appData = new AppData(fields);
            Apps.Add(appData);
        }

        public long AllAppsCount()
            => Apps.Count;

        public long AppsAboveXRatingCount(double x)
        {
            throw new NotImplementedException();
        }

        public long RecentlyUpdatedCount(DateTime boundary)
        {
            throw new NotImplementedException();
        }

        public string RecentlyUpdatedFreqCat(DateTime boundary)
        {
            throw new NotImplementedException();
        }

        public List<string> MostRatedCategories(double ratingBoundary, int n)
        {
            throw new NotImplementedException();
        }

        public double TopQuarterBoundary()
        {
            throw new NotImplementedException();
        }

        public Tuple<string,string> ExtremeMeanUpdateElapse(DateTime today)
        {
            throw new NotImplementedException();
        }

        public List<string> XMostProfitables(int x)
        {
            throw new NotImplementedException();
        }

        public List<string> XCoolestApps(int x, Func<AppData,double> criteria)
        {
            throw new NotImplementedException();
        }




    }
}