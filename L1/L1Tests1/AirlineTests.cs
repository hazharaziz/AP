using Microsoft.VisualStudio.TestTools.UnitTesting;
using L1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class AirlineTests
    {
        [TestMethod()]
        public void AirlineTest()
        {
            var airline1 = new Airline("Mahan");
            string exp = "Mahan";

            Assert.AreEqual(exp, airline1.Name);
        }
    }
}