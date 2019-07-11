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
    public class XmlLogFormatterTests
    {
        [TestMethod()]
        public void XmlFormatTest()
        {
            LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                "student created", ("FirstName", "Pegah"), ("LastName", "Ayati"));
            string actualLog = XmlLogFormatter.Instance.Format(logEntry);
            string expectedString1 = "<Source>Client</Source><Level>Debug</Level><Message>student created</Message><ProcessId>";
            string expectedString2 = "</ThreadId><NameValuePairs><ValueTupleOfStringString><Item1>FirstName</Item1><Item2>Pegah</Item2></ValueTupleOfStringString><ValueTupleOfStringString><Item1>LastName</Item1><Item2>Ayati</Item2></ValueTupleOfStringString></NameValuePairs>";
            Assert.IsTrue(actualLog.Contains(expectedString1));
            Assert.IsTrue(actualLog.Contains(expectedString2));
        }
    }
}