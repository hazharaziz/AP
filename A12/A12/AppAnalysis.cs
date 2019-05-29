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

        /// <summary>
        /// AppAnalysis Class Constructor
        /// </summary>
        private AppAnalysis() { }

        /// <summary>
        /// AppAnalysisFactory Method analysing the data of a csv file 
        /// </summary>
        /// <param name="csvAddress"></param>
        /// <returns></returns>
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

        /// <summary>
        /// AppendApp Method appending the app data to the list of the apps
        /// </summary>
        /// <param name="fields"></param>
        public void AppendApp(string[] fields)
            => Apps.Add(new AppData(fields));

        /// <summary>
        /// AllAppsCount Method returning the Apps list count
        /// </summary>
        /// <returns></returns>
        public long AllAppsCount()
            => Apps.Count;

        /// <summary>
        /// AppsAboveXRatingCount Method returning the number of apps with rating above a given number
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public long AppsAboveXRatingCount(double x)
            => Apps.Where(d => d.Rating >= x).ToList().Count;

        /// <summary>
        /// RecentlyUpdatedCount Method returning the number of apps updated after a given datetime
        /// </summary>
        /// <param name="boundary"></param>
        /// <returns></returns>
        public long RecentlyUpdatedCount(DateTime boundary)
            => Apps.Where(x => DateTime.Compare(x.LastUpdate, boundary) >= 0).ToList().Count;

        /// <summary>
        /// RecentlyUpdatedApps Method returning the apps updated after a given datetime
        /// </summary>
        /// <param name="boundary"></param>
        /// <returns></returns>
        public List<AppData> RecentlyUpdatedApps(DateTime boundary)
            => Apps.Where(x => DateTime.Compare(x.LastUpdate, boundary) >= 0).ToList();

        /// <summary>
        /// RecentlyUpdatedFreqCat Method returning the most repeated app category after a given datetime
        /// </summary>
        /// <param name="boundary"></param>
        /// <returns></returns>
        public string RecentlyUpdatedFreqCat(DateTime boundary)
            => RecentlyUpdatedApps(boundary).GroupBy(d => d.Category)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key).First();

        public List<string> MostRatedCategories(double ratingBoundary, int n)
        {
            throw new NotImplementedException();
        }

        public double TopQuarterBoundary()
        {
            throw new NotImplementedException();
        }

        public Tuple<string, string> ExtremeMeanUpdateElapse(DateTime today)
        {
            throw new NotImplementedException();
        }

        public List<string> XMostProfitables(int x)
        {
            throw new NotImplementedException();
        }

        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
        {
            throw new NotImplementedException();
        }




    }
}