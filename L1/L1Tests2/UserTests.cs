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
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            string expectedFullName = "Sepehr Hashemi";
            string expectedID = "9643";
            string expectedPhoneNumber = "+981111111111";
            double expectedAccount = 100000;
            TestString(expectedFullName, TestData.user1.FullName);
            TestString(expectedID, TestData.user1.NationalID);
            TestString(expectedPhoneNumber, TestData.user1.PhoneNumber);
            TestDouble(expectedAccount, TestData.user1.Account);
        }

        private void TestDouble(double expectedDouble, double functionalDouble)
        {
            Assert.AreEqual(expectedDouble, functionalDouble);
        }

        private void TestString(string expectedString, string functionalString)
        {
            Assert.AreEqual(expectedString, functionalString);
        }

        [TestMethod()]
        public void ReserveTest()
        {
            TestData.user3.Reserve(TestData.ticket4);
            double expectedAccount = -550000;
            int expectedCapacity = 99;
            User expectedBuyer = TestData.ticket4.Buyer;
            Assert.AreEqual(true, TestData.user3.Tickets.Contains(TestData.ticket4));
            TestDouble(expectedAccount, TestData.user3.Account);
            TestInteger(expectedCapacity, TestData.flight1.Capacity);
            TestUser(expectedBuyer, TestData.ticket4.Buyer);

            TestData.user4.Reserve(TestData.ticket5);
            expectedAccount = -50000;
            expectedCapacity = 98;
            expectedBuyer = TestData.ticket5.Buyer;
            Assert.AreEqual(true, TestData.user4.Tickets.Contains(TestData.ticket5));
            TestDouble(expectedAccount, TestData.user4.Account);
            TestInteger(expectedCapacity, TestData.flight1.Capacity);
            TestUser(expectedBuyer, TestData.ticket5.Buyer);
        }

        private void TestUser(User expectedUser, User functionalUser)
        {
            Assert.AreEqual(expectedUser, functionalUser);
        }

        private void TestInteger(int expectedInt, int functionalInt)
        {
            Assert.AreEqual(expectedInt, functionalInt);
        }

        [TestMethod()]
        public void CancelTest()
        {
            TestData.user6.Reserve(TestData.ticket6);
            TestData.user6.Cancel(TestData.ticket6);
            double expectedAccount = -54200;
            int expectedCapacity = 70;
            User expectedBuyer = null;
            Assert.AreEqual(true, !TestData.user6.Tickets.Contains(TestData.ticket6));
            TestDouble(expectedAccount, TestData.user6.Account);
            TestInteger(expectedCapacity, TestData.flight4.Capacity);
            TestUser(expectedBuyer, TestData.ticket6.Buyer);
        }

        [TestMethod()]
        public void DateFilteredTicketsTest()
        {
            DateTime startDate = new DateTime(year: 2018, month: 2, day: 10);
            DateTime endDate = new DateTime(year: 2020, month: 8, day: 10);
            List<Ticket> expectedTickets = TestData.user7.DateFilteredTickets(startDate, endDate);
            CollectionAssert.AreEqual(expectedTickets, TestData.user7.DateFilteredTickets(startDate,endDate));
        }

        [TestMethod()]
        public void NowruzTicketsTest()
        {
            List<Ticket> expectedTickets = TestData.user8.NowruzTickets();
            CollectionAssert.AreEqual(expectedTickets, TestData.user8.NowruzTickets());
        }

        [TestMethod()]
        public void AirlineTicketsTest()
        {
            List<Ticket> expectedAirlines = TestData.user8.AirlineTickets(TestData.airline4);
            CollectionAssert.AreEqual(expectedAirlines, TestData.user8.AirlineTickets(TestData.airline4));
        }

        [TestMethod()]
        public void RouteTicketsTest()
        {
            List<Ticket> expectedRoutes = TestData.user9.RouteTickets(TestData.flight5.Source, TestData.flight5.Destination);
            CollectionAssert.AreEqual(expectedRoutes, TestData.user9.RouteTickets(TestData.flight5.Source, TestData.flight5.Destination));
        }
    }
}