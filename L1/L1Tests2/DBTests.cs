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
    public class DBTests
    {
        [TestMethod()]
        public void AddAirlineTest()
        {
            List<Airline> expectedAirlines = new List<Airline>() { TestData.airline1, TestData.airline2, TestData.airline3, TestData.airline4 };
            CollectionAssert.AreEqual(expectedAirlines, DB.Airlines);
        }

        [TestMethod()]
        public void AddTicketTest()
        {
            List<Ticket> expectedTickets = DB.Tickets;
            CollectionAssert.AreEqual(expectedTickets, DB.Tickets);
        }

        [TestMethod()]
        public void AddUserTest()
        {
            List<User> expectedUsers = DB.Users;
            CollectionAssert.AreEqual(expectedUsers, DB.Users);
        }

        [TestMethod()]
        public void AddFlightTest()
        {
            List<Flight> expectedFlights = DB.Flights;
            CollectionAssert.AreEqual(expectedFlights, DB.Flights);
        }

        [TestMethod()]
        public void DeleteAirlineTest()
        {
            DB.DeleteAirline(TestData.airline3);
            List<Airline> expectedAirlines = DB.Airlines;
            CollectionAssert.AreEqual(expectedAirlines, DB.Airlines);
        }

        [TestMethod()]
        public void DeleteTicketTest()
        {
            DB.DeleteTicket(TestData.ticket12);
            List<Ticket> expectedTickets = DB.Tickets;
            CollectionAssert.AreEqual(expectedTickets, DB.Tickets);
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            DB.DeleteUser(TestData.user7);
            List<User> expectedUsers = DB.Users;
            CollectionAssert.AreEqual(expectedUsers, DB.Users);
        }

        [TestMethod()]
        public void DeleteFlightTest()
        {
            DB.DeleteFlight(TestData.flight3);
            List<Flight> expectedFlights = DB.Flights;
            CollectionAssert.AreEqual(expectedFlights, DB.Flights);
        }

        [TestMethod()]
        public void MostExpensiveTicketTest()
        {
            Ticket expectedTicket = TestData.ticket17;
            Assert.AreEqual(expectedTicket, DB.MostExpensiveTicket());
        }

        [TestMethod()]
        public void FavouriteAirlineTest()
        {
            //Ticket ticket1 = new Ticket(TestData.flight1, 250000, null);
            //Ticket ticket2 = new Ticket(TestData.flight3, 353000, null);
            //Ticket ticket3 = new Ticket(TestData.flight2, 550000, null);
            //Ticket ticket4 = new Ticket(TestData.flight1, 650000, null);
            //Ticket ticket5 = new Ticket(TestData.flight1, 150000, null);
            //Ticket ticket6 = new Ticket(TestData.flight4, 257000, null);
            //Ticket ticket7 = new Ticket(TestData.flight3, 455000, null);
            //Ticket ticket8 = new Ticket(TestData.flight5, 150000, null);
            //Ticket ticket9 = new Ticket(TestData.flight5, 850000, null);
            //Ticket ticket10 = new Ticket(TestData.flight5, 340000, null);
            //Ticket ticket11 = new Ticket(TestData.flight2, 160000, null);
            //Ticket ticket12 = new Ticket(TestData.flight1, 190000, null);
            //Ticket ticket13 = new Ticket(TestData.flight2, 699000, null);
            //Ticket ticket14 = new Ticket(TestData.flight5, 175000, null);
            //Ticket ticket15 = new Ticket(TestData.flight1, 250000, null);
            //Ticket ticket16 = new Ticket(TestData.flight4, 503000, null);
            //Ticket ticket17 = new Ticket(TestData.flight2, 2450000, null);
            //Ticket ticket18 = new Ticket(TestData.flight1, 225000, null);
            //Ticket ticket19 = new Ticket(TestData.flight3, 655000, null);
            //Ticket ticket20 = new Ticket(TestData.flight3, 750000, null);

            var a = DB.FavouriteAirline();
            Airline expectedAirline = TestData.airline1;
            Assert.AreEqual(expectedAirline, DB.FavouriteAirline());
        }

    [TestMethod()]
    public void UsersDebtsTest()
    {
        double expectedDebts = 0;
        Assert.AreEqual(expectedDebts, DB.UsersDebts());
    }

    [TestMethod()]
    public void FavouriteDestinationTest()
{
        Flight flight1 = new Flight("1144", TestData.airline1, 100, "Hamedan", "Tehran", new DateTime(year: 2019, month: 3, day: 21));
        Flight flight2 = new Flight("1217", TestData.airline2, 50, "Tehran", "Esfahan", new DateTime(year: 2019, month: 3, day: 27));
        Flight flight3 = new Flight("4113", TestData.airline3, 100, "Rasht", "Yazd", new DateTime(year: 2019, month: 5, day: 11));
        Flight flight4 = new Flight("9525", TestData.airline1, 70, "Tehran", "Shiraz", new DateTime(year: 2019, month: 4, day: 9));
        Flight flight5 = new Flight("1618", TestData.airline4, 60, "Mashhad", "Tehran", new DateTime(year: 2019, month: 8, day: 15));
        string expectedDest = "Tehran";
        Assert.AreEqual(expectedDest, DB.FavouriteDestination());
    }
}
}