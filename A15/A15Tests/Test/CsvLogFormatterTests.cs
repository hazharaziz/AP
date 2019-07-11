using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass()]
    public class CsvLogFormatterTests
    {
        [TestMethod()]
        public void CsvFormatTest()
        {
            LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                "student created", ("FirstName", "Pegah"), ("LastName", "Ayati"));

            string expectedLogLineEnd = "student created,'FirstName':'Pegah','LastName':'Ayati'";
            string logLine = CsvLogFormatter.Instance.Format(logEntry);

            Assert.IsTrue(logLine.EndsWith(expectedLogLineEnd));
            Assert.IsTrue(logLine.StartsWith("Debug"));
            Assert.IsTrue(logLine.Contains(",Client,"));
        }
    }
}