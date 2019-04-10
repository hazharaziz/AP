using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class User
    {
        public string FullName;
        public string NationalID;
        public string PhoneNumber;
        public List<Ticket> Tickets;
        public double Account;

        public User(string fullName, string nationalID, string phoneNumber,double account = 0)
        {
            FullName = fullName;
            NationalID = nationalID;
            PhoneNumber = phoneNumber;
            Tickets = new List<Ticket>();
            Account = account;
            DB.AddUser(this);
        }

        /// <summary>
        /// reserve new ticket
        /// do necessary changes on Ticket, Flight, and User properties.
        /// </summary>
        /// <param name="ticket"></param>
        public void Reserve(Ticket ticket)
        {
            Tickets.Add(ticket);
            Account -= ticket.Price;
            ticket.Flight.Capacity -= 1;
            ticket.Buyer = this;
        }

        /// <summary>
        /// cancel ticket reservation
        /// do necessary changes on Ticket, Flight, and User properties.
        /// 40% of the ticket price backs to the buyer account
        /// </summary>
        /// <param name="ticket"></param>
        public void Cancel(Ticket ticket)
        {
            Tickets.Remove(ticket);
            Account += (0.4 * ticket.Price);
            ticket.Flight.Capacity += 1;
            ticket.Buyer = null;
        }

        /// <summary>
        /// returns tickets with dates between two significant dates
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public List<Ticket> DateFilteredTickets(DateTime startDateTime, DateTime endDateTime)
        {
            List<Ticket> dateFilteredTickets = new List<Ticket>();

            foreach (Ticket ticket in DB.Tickets)
            {
                if (ticket.IsSold() == false)
                {
                    if ((DateTime.Compare(startDateTime,ticket.Flight.FlyDate) <= 0) && (DateTime.Compare(endDateTime,ticket.Flight.FlyDate) >= 0))
                    {
                        dateFilteredTickets.Add(ticket);
                    }    
                }
            }

            return dateFilteredTickets;
        }

        /// <summary>
        /// returns tickets with dates between 18 March, 28 March
        /// </summary>
        /// <returns></returns>
        public List<Ticket> NowruzTickets()
        {
            List<Ticket> nowruzTickets = new List<Ticket>();

            foreach (Ticket ticket in DB.Tickets)
            {
                if (!ticket.IsSold())
                {
                    if (ticket.Flight.FlyDate.Month == 3)
                    {
                        if ((ticket.Flight.FlyDate.Day >= 18) && (ticket.Flight.FlyDate.Day <= 28))
                        {
                            nowruzTickets.Add(ticket);
                        }
                    }
                }
            }

            return nowruzTickets;
        }

        /// <summary>
        /// returns tickets of a significant airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(Airline airline)
        {
            List<Ticket> airlineTickets = new List<Ticket>();

            foreach (Ticket ticket in DB.Tickets)
            {
                if (ticket.Flight.Airline == airline)
                {
                    airlineTickets.Add(ticket);
                }
            }

            return airlineTickets;
        }

        /// <summary>
        /// returns tickets with a significent route
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public List<Ticket> RouteTickets(string source, string dest)
        {
            List<Ticket> routeTickets = new List<Ticket>();

            foreach (Ticket ticket in DB.Tickets)
            {
                if ((ticket.Flight.Source == source) && (ticket.Flight.Destination == dest))
                {
                    routeTickets.Add(ticket);
                }
            }

            return routeTickets;
        }
        
    }
}
