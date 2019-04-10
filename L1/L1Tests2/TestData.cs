using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace L1.Tests
{

    public class TestData
    {
        //Users
        public static User user1 = new User("Sepehr Hashemi", "9643", "+981111111111", 100000);
        public static User user2 = new User("Sepehr Hashemi", "3312", "+981111111112", 100000);
        public static User user3 = new User("Sepehr Hashemi", "9856", "+981111111113", 100000);
        public static User user4 = new User("Sepehr Hashemi", "4065", "+981111111114", 100000);
        public static User user5 = new User("Sepehr Hashemi", "1176", "+981111111115", 100000);
        public static User user6 = new User("Sepehr Hashemi", "1327", "+981111111116", 100000);
        public static User user7 = new User("Sepehr Hashemi", "9845", "+981111111117", 100000);
        public static User user8 = new User("Sepehr Hashemi", "1098", "+981111111118", 100000);
        public static User user9 = new User("Sepehr Hashemi", "8865", "+981111111119", 100000);
        public static User user10 = new User("Sepehr Hashemi", "9010", "+981111111110", 100000);

        //Airlines
        public static Airline airline1 = new Airline("Mahan");
        public static Airline airline2 = new Airline("IranAir");
        public static Airline airline3 = new Airline("KishAir");
        public static Airline airline4 = new Airline("Asemaan");

        //Flights
        public static Flight flight1 = new Flight("1144", airline1, 100, "Hamedan", "Tehran", new DateTime(year: 2019, month: 3, day: 21));
        public static Flight flight2 = new Flight("1217", airline2, 50, "Tehran", "Esfahan", new DateTime(year: 2019, month: 3, day: 27));
        public static Flight flight3 = new Flight("4113", airline3, 100, "Rasht", "Yazd", new DateTime(year: 2019, month: 5, day: 11));
        public static Flight flight4 = new Flight("9525", airline1, 70, "Tehran", "Shiraz", new DateTime(year: 2019, month: 4, day: 9));
        public static Flight flight5 = new Flight("1618", airline4, 60, "Mashhad", "Tehran", new DateTime(year: 2019, month: 8, day: 15));

        //Tickets
        public static Ticket ticket1 = new Ticket(flight1, 250000, null);
        public static Ticket ticket2 = new Ticket(flight3, 353000, null);
        public static Ticket ticket3 = new Ticket(flight2, 550000, null);
        public static Ticket ticket4 = new Ticket(flight1, 650000, null);
        public static Ticket ticket5 = new Ticket(flight1, 150000, null);
        public static Ticket ticket6 = new Ticket(flight4, 257000, null);
        public static Ticket ticket7 = new Ticket(flight3, 455000, null);
        public static Ticket ticket8 = new Ticket(flight5, 150000, null);
        public static Ticket ticket9 = new Ticket(flight5, 850000, null);
        public static Ticket ticket10 = new Ticket(flight5, 340000, null);
        public static Ticket ticket11 = new Ticket(flight2, 160000, null);
        public static Ticket ticket12 = new Ticket(flight1, 190000, null);
        public static Ticket ticket13 = new Ticket(flight2, 699000, null);
        public static Ticket ticket14 = new Ticket(flight5, 175000, null);
        public static Ticket ticket15 = new Ticket(flight1, 250000, null);
        public static Ticket ticket16 = new Ticket(flight4, 503000, null);
        public static Ticket ticket17 = new Ticket(flight2, 2450000, null);
        public static Ticket ticket18 = new Ticket(flight1, 225000, null);
        public static Ticket ticket19 = new Ticket(flight3, 655000, null);
        public static Ticket ticket20 = new Ticket(flight3, 750000, null);
    }
}
