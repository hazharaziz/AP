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

        /// <summary>
        /// MostRatedCategories returns the n first categorires with ratings more than the rating boundary
        /// </summary>
        /// <param name="ratingBoundary"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<string> MostRatedCategories(double ratingBoundary, int n)
            => Apps.Where(d => (d.Rating > ratingBoundary))
            .GroupBy(d => d.Category)
            .OrderByDescending(g => g.Count())
            .Take(n)
            .Select(g => g.Key)
            .ToList();

        /// <summary>
        /// TopQuarterBoundary Method returns the top quarter boundary of the "PHOTOGRAPHY" category
        /// </summary>
        /// <returns></returns>
        public double TopQuarterBoundary()
            => Apps.Where(d => d.Category == "PHOTOGRAPHY").OrderByDescending(d => d.Rating).First().Rating - 0.5;

        /// <summary>
        /// ExtremeMeanUpdateElapse Method returning the average of the max and min of the elapsed update times
        /// </summary>
        /// <param name="today"></param>
        /// <returns></returns>
        public Tuple<string, string> ExtremeMeanUpdateElapse(DateTime today)
        {
            var data = Apps.GroupBy(d => d.Name)
                .OrderByDescending(g => g.Average(a => a.LastUpdate.Ticks - today.Ticks))
                .Select(g => g.Key)
                .ToList();
            return new Tuple<string, string>(data[0],data[data.Count -1]);   
        }

        /// <summary>
        /// XMostProfitables Method returning the most installed apps
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<string> XMostProfitables(int x)
            => Apps.Where(d => d.IsFree == 0)
            .OrderByDescending(d => d.Price * d.Installs)
            .Select(g => $"{g.Name}")
            .Take(x)
            .ToList();

        /// <summary>
        /// Criteria Delegate returning the criteria of the given app
        /// </summary>
        /// <param name="appData"></param>
        /// <returns></returns>
        Func<AppData, double> criteria = (app) => (app.Installs * app.Rating) / 1000;

        /// <summary>
        /// XCoolestApps Method returning x coolest apps
        /// </summary>
        /// <param name="x"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
            => Apps.Where(d => d.Installs * d.Rating == criteria(d))
            .Select(d => d.Name).Take(x).ToList();
    }
}