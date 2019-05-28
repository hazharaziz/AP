using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace A12
{
    public class AppAnalysis
    {

        public List<AppData> Apps { get; set; }

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
                    appAnalysis.AppendApp(fields);
                }

            }

            return appAnalysis;
        }


        public long AllAppsCount()
        {
            throw new NotImplementedException();
        }

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