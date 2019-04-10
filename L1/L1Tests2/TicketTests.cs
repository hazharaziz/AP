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
    public class TicketTests
    {
        [TestMethod()]
        public void TicketTest()
        {
            Assert.AreEqual(TestData.flight1, TestData.ticket1.Flight);
            Assert.AreEqual(TestData.flight3, TestData.ticket2.Flight);
            Assert.AreEqual(TestData.flight2, TestData.ticket3.Flight);
        }

        [TestMethod()]
        public void IsSoldTest()
        {
            Assert.AreEqual(null, TestData.ticket1.Buyer);
            Assert.AreNotEqual(TestData.user1, TestData.ticket2.Buyer);
        }
    }
}