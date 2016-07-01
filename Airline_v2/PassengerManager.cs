using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_v2
{
    class PassengerManager : Manager
    {


        ///manage passengers

        /// add passengers
        public void Add(Flight[] flights, int index) {
            bool added = false;
            
                for (int i = 0; i < flights[index].Length; i++)
                {
                    if (flights[index][i] == null)
                    {
                        Passenger psgnr = new Passenger();
                        flights[index][i] = psgnr.Add();
                        added = true;
                        break;
                    }
                }
            
            if (!added) Console.WriteLine("No free places on this flight");
        }

        ///edit passenger info
        public void Edit(Flight[] flights, string pass) {
            bool found = false;
            foreach(Flight flight in flights)
            { 
                for (int i = 0; i < flight.Length; i++)
                {
                    if (flight[i] != null && string.Equals(flight[i].Passport, pass))
                    {
                        flight[i] = flight[i].EditInfo(flight[i]);
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            if (!found) Console.WriteLine("Passenger wasn't found!");
        }
        /// delete passenger
        public void Delete(Flight[] flights, string pass) {
            bool found = false;
            foreach (Flight flight in flights)
            {
                for (int i = 0; i < flight.Length; i++)
                {
                    if (flight[i] != null && string.Equals(flight[i].Passport, pass))
                    {
                        flight[i] = null;
                        Console.WriteLine("Passenger has been deleted");
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            if (!found) Console.WriteLine("Passenger with such pass was not found");
        }

        public Passenger SearchByName(Flight[] flights, string criteria, string name)
        {
            //bool done = false;
            foreach (Flight flight in flights)
            {
                if (flight != null)
                {

                    for (int i = 0; i < flight.Length; i++)
                    {
                        if (flight[i] != null)
                        {
                            if (string.Equals(criteria, "F"))
                            {
                                if (flight[i] != null && string.Equals(flight[i].FName, name.ToUpper())) return flight[i];
                            }
                            else if (string.Equals(criteria, "L"))
                            {
                                if (flight[i] != null && string.Equals(flight[i].LName, name.ToUpper())) return flight[i];
                            }
                            else if (string.Equals(criteria, "N"))
                            {
                                int number = Program.InputValidation(name, 1, 999);
                                if (flight[i] != null && flight.FlightNumber == number) return flight[i];
                            }
                            else if (flight[i] != null && string.Equals(criteria, "P"))      
                            {
                                if (string.Equals(flight[i].Passport, name)) return flight[i];
                            }
                            
                        }
                    }
                }
            }
            return null;
        }

    }
}
