using Microsoft.VisualStudio.TestTools.UnitTesting;
using L1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.Tests
{
    [TestClass()]
    public class AirlineTests
    {
        [TestMethod()]
        public void AirlineTest()
        {
            string exp = "Mahan";
            Assert.AreEqual(exp, TestData.airline1.Name);

            exp = "IranAir";
            Assert.AreEqual(exp, TestData.airline2.Name);

            exp = "KishAir";
            Assert.AreEqual(exp, TestData.airline3.Name);

            exp = "Asemaan";
            Assert.AreEqual(exp, TestData.airline4.Name);
        }
    }
}