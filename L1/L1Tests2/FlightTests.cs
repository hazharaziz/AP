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
    public class FlightTests
    {
        [TestMethod()]
        public void FlightTest()
        {
            string expectedFlightID = "1618";
            Airline expectedAirline = TestData.airline4;
            int expectedCapacity = 60;
            string expectedSource = "Mashhad";
            string expectedDest = "Tehran";
            DateTime expectedDate = new DateTime(year: 2019, month: 8, day: 15);
            Assert.AreEqual(expectedFlightID, TestData.flight5.FlightID);
            Assert.AreEqual(expectedAirline, TestData.flight5.Airline);
            Assert.AreEqual(expectedCapacity, TestData.flight5.Capacity);
            Assert.AreEqual(expectedSource, TestData.flight5.Source);
            Assert.AreEqual(expectedDest, TestData.flight5.Destination);
            Assert.AreEqual(expectedDate, TestData.flight5.FlyDate);

            expectedFlightID = "9525";
            expectedAirline = TestData.airline1;
            expectedCapacity = 70;
            expectedSource = "Tehran";
            expectedDest = "Shiraz";
            expectedDate = new DateTime(year: 2019, month: 4, day: 9);
            Assert.AreEqual(expectedFlightID, TestData.flight4.FlightID);
            Assert.AreEqual(expectedAirline, TestData.flight4.Airline);
            Assert.AreEqual(expectedCapacity, TestData.flight4.Capacity);
            Assert.AreEqual(expectedSource, TestData.flight4.Source);
            Assert.AreEqual(expectedDest, TestData.flight4.Destination);
            Assert.AreEqual(expectedDate, TestData.flight4.FlyDate);
        }

        [TestMethod()]
        public void IsFullTest()
        {
            Assert.AreEqual(false, TestData.flight3.IsFull());
            Assert.AreNotEqual(true, TestData.flight1.IsFull());
        }
    }
}