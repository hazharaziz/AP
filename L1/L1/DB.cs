using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class DB
    {
        public static List<Airline> Airlines = new List<Airline>();

        public static List<User> Users = new List<User>();

        public static List<Ticket> Tickets = new List<Ticket>();

        public static List<Flight> Flights = new List<Flight>();


        public static void AddAirline(Airline airline)
        {
            Airlines.Add(airline);
        }

        public static void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public static void DeleteAirline(Airline airline)
        {
            Airlines.Remove(airline);
        }

        public static void DeleteTicket(Ticket ticket)
        {
            Tickets.Remove(ticket);
        }

        public static void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public static void DeleteFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        /// <summary>
        /// returns most expensive ticket
        /// </summary>
        /// <returns></returns>
        public static Ticket MostExpensiveTicket()
        {
            Ticket mostExpensiveTicket = null;
            double maxPrice = 0;
            
            for (int i = 0; i < Tickets.Count; i++)
            {
                if (Tickets[i].Price > maxPrice)
                {
                    maxPrice = Tickets[i].Price;
                    mostExpensiveTicket = Tickets[i];
                }
            }

            return mostExpensiveTicket;
        }

        /// <summary>
        /// returns airline with most sold tickets
        /// </summary>
        /// <returns></returns>
        public static Airline FavouriteAirline()
        {
            Dictionary<Airline, int> airlineCount = new Dictionary<Airline, int>();
            var airlines = new HashSet<Airline>(Airlines);

            foreach (Airline airline in airlines)
            {
                airlineCount[airline] = 0;
            }

            foreach (Ticket ticket in Tickets)
            {
                if (!airlineCount.Keys.Contains(ticket.Flight.Airline))
                {
                    continue;
                }
                else
                {
                    airlineCount[ticket.Flight.Airline]++;
                }
                
            }

            int max = airlineCount.Values.Max();
            Airline favouriteAirline = null;
            foreach (Airline airline in airlineCount.Keys)
            {
                if (airlineCount[airline] == max)
                {
                    favouriteAirline = airline;
                }
            }

            return favouriteAirline;
        }

        /// <summary>
        /// returns amount of money users should pay from their credit accounts
        /// </summary>
        /// <returns></returns>
        public static double UsersDebts()
        {
            double debts = 0;

            foreach (Ticket ticket in Tickets)
            {
                if (ticket.IsSold())
                {
                    debts += ticket.Price;
                }
            }

            return debts;
        }

        /// <summary>
        /// returns passengers favourite destination
        /// </summary>
        /// <returns></returns>
        public static string FavouriteDestination()
        {
            Dictionary<string, int> destCount = new Dictionary<string, int>();
            var dests = new HashSet<string>();

            foreach (Flight flight in Flights)
            {
                dests.Add(flight.Destination);
            }

            foreach (string dest in dests)
            {
                destCount[dest] = 0;
            }

            foreach (Flight flight in Flights)
            {
                destCount[flight.Destination]++;
            }

            int max = destCount.Values.Max();
            string favouriteDestination = null;

            foreach (string dest in destCount.Keys)
            {
                if (destCount[dest] == max)
                {
                    favouriteDestination = dest;
                }
            }

            return favouriteDestination;
        }
    }
}
