using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.Tests
{
    [TestClass()]
    public class FlightTests
    {
        [TestMethod()]
        public void FlightTest()
        {
            var airline1 = new Airline("Mahan");
            var flight1 = new Flight("1144", airline1, 100, "Hamedan", "Mashhad", new DateTime(year: 2019, month: 3, day: 21));

        }

        [TestMethod()]
        public void IsFullTest()
        {
            Assert.Fail();
        }
    }
}