using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_v2
{
    class FlightManager : Manager
    {
        //Flight[] flights;
        ///manage flights
        ///

        /// Add flight
        /// 
        public void Add(Flight[] flights)
        {
            bool added = false;
            for (int i = 0; i < Program.flights.Length; i++)
            {
                if (Program.flights[i] == null)
                {
                    Flight fl = new Flight();
                    Program.flights[i] = fl.Add();
                    added = true;
                    break;
                }
            }
            if (!added) Console.WriteLine("No free space for new flight!");
        }
        /// edit flight
        /// 
        public void Edit(Flight[] flights, int index)
        {

            flights[index] = flights[index].EditInfo(flights[index]);
            Console.WriteLine("Flight has been edited");
        }

        ///delete flight
        ///
        public void Delete(Flight[] flights, int index)
        {

            flights[index] = null;
            Console.WriteLine("Flight has been deleted");
        }

        public int SearchFlightByNumber(Flight[] flights, int number)
        {
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i] != null && flights[i].FlightNumber == number)
                {
                    return i;
                }
            }
            Console.WriteLine("Flight not found");
            return -1;
        }

        public Flight SearchByPrice(Flight flight, decimal price)
        {
            
            if (flight != null)
            {
                for (int i = 0; i < flight.Length; i++)
                {
                    if (flight[i] != null)
                    {
                        if (flight[i].FTicket.TClass == 0 && flight[i].FTicket.TPrice < price) return flight;

                    }
                }
            }
           
            return null;
        }
    }
}
