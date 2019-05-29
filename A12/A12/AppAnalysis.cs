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

            return appAnalysis;
        }

        public void AppenApp(string[] fields)
            => Apps.Add(new AppData(fields));

        public long AllAppsCount()
            => Apps.Count;

        public long AppsAboveXRatingCount(double x)
            => Apps.Where(d => d.Rating >= x).ToList().Count;

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