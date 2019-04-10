using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class Flight 
    {
        //Properties:
        //FlightID: string
        //Airline: Airline
        //Capacity: int
        //Source: string
        //Destination: string
        //FlyDate: DateTime

        
        public string FlightID { get; set; }
        public Airline Airline { get; set; }
        public int Capacity { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime FlyDate { get; set; }


        /// <summary>
        /// set properties and add the object to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airline"></param>
        /// <param name="capacity"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dateTime"></param>

        public Flight(string id, Airline airline, int capacity, string source, string dest,
            DateTime dateTime)
        {
            FlightID = id;
            Airline = airline;
            Capacity = capacity;
            Source = source;
            Destination = dest;
            FlyDate = dateTime;
            DB.AddFlight(this);
        }

        public bool IsFull()
        {
            if (Capacity > 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

    }
}
