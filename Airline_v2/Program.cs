using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_v2
{

    class Program
    {

        public static Flight[] flights = new Flight[5];





        static void Main(string[] args)
        {
            flights[0] = new Flight("ARRAIVAL", DateTime.Parse("12.12.2111 12:21"), 111, "LONDON", "22", "10", FlightStatus.Arrived);
            flights[1] = new Flight("DEPARTURE", DateTime.Parse("12.12.2011 11:11"), 222, "MADRID", "55", "9", FlightStatus.CheckIn);
            flights[2] = new Flight("ARRAIVAL", DateTime.Parse("12.12.2011 13:11"), 333, "DUBLIN", "33", "7", FlightStatus.ExpectedAt);
            flights[0][0] = new Passenger("JOHN", "DOE", "USA", "111", DateTime.Parse("10.11.2000"), "MALE", new FlightTicket(FlightClass.Economy, 450));
            flights[1][0] = new Passenger("PATHY", "SMITH", "UK", "123", DateTime.Parse("11.10.1980"), "FEMALE", new FlightTicket(FlightClass.Economy, 500));
            flights[1][1] = new Passenger("STEF", "SEYMOUR", "UK", "234", DateTime.Parse("10.09.1975"), "FEMALE", new FlightTicket(FlightClass.Business, 2444));
            flights[2][2] = new Passenger("ANGY", "JOLY", "USA", "345", DateTime.Parse("10.08.1975"), "FEMALE", new FlightTicket(FlightClass.Business, 3000));

            do
            {
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"                            Main menu of Airline information system

                    1.  Print(view) ALL FLIGHTS (without passengers)

                    2.  Print(view) ALL FLIGHT’s PASSENGERS (search by flight number)

                    3.  SEARCH passengers from any flight by FIRST NAME (partial coincidence)

                    4.  SEARCH passengers from any flight by LAST NAME (partial coincidence)

                    5.  SEARCH passengers from any flight by FLIGHT NUMBER

                    6.  SEARCH passengers from any flight by PASSPORT (partial coincidence)

                    7.  SEARCH all flights(without passengers) with the PRICE of ECONOMY ticket 
                        lower than user input dollars

                    8.  MANAGE FLIGHTS - input, editing and deleting

                    9.  MANAGE PASSENGERS - input, editing and deleting

          
                    Please choose menu item and press apropriate key number (1-9)
                    ");
                    try
                    {
                        string item = Console.ReadLine();
                        int menuItem = InputValidation(item, 1, 9);
                        FlightManager fm = new FlightManager();
                        PassengerManager pm = new PassengerManager();
                        switch (menuItem)
                        {
                            case 1:
                                AllFlightsInfo();
                                Console.WriteLine("");
                                break;
                            case 2:
                                AllFlightPassengers();
                                Console.WriteLine("");
                                break;
                            case 3:
                                Console.WriteLine("Please, enter passenger's first name");
                                string name = Console.ReadLine();
                                string criteria = "F";
                                if (pm.SearchByName(flights, criteria, name) != null)
                                {
                                    Console.WriteLine("First name   Last name   Nationality  Passport            Birthday            Sex            Ticket info");
                                    Console.WriteLine("========================================================================================================");
                                    Console.WriteLine(pm.SearchByName(flights, criteria, name).ToString());
                                }
                                else {
                                    Console.WriteLine("No passengers found!");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Please, enter passenger's last name");
                                name = Console.ReadLine();
                                criteria = "L";
                                if (pm.SearchByName(flights, criteria, name) != null)
                                {
                                    Console.WriteLine("First name   Last name   Nationality  Passport            Birthday            Sex            Ticket info");
                                    Console.WriteLine("========================================================================================================");
                                    Console.WriteLine(pm.SearchByName(flights, criteria, name).ToString());
                                }
                                else {
                                    Console.WriteLine("No passengers found!");
                                }
                                Console.WriteLine("");
                                break;
                            case 5:
                                Console.WriteLine("Please, enter flight number for passengers list");
                                name = Console.ReadLine();
                                criteria = "N";
                                if (pm.SearchByName(flights, criteria, name) != null)
                                {
                                    Console.WriteLine("First name   Last name   Nationality  Passport            Birthday            Sex            Ticket info");
                                    Console.WriteLine("========================================================================================================");
                                    Console.WriteLine(pm.SearchByName(flights, criteria, name).ToString());
                                }
                                else {
                                    Console.WriteLine("No info found!");
                                }
                                Console.WriteLine("");
                                break;
                            case 6:
                                Console.WriteLine("Please, enter passenger's passport");
                                name = Console.ReadLine();
                                criteria = "P";
                                if(pm.SearchByName(flights, criteria, name) != null) {
                                    Console.WriteLine("First name   Last name   Nationality  Passport            Birthday            Sex            Ticket info");
                                    Console.WriteLine("========================================================================================================");
                                    Console.WriteLine(pm.SearchByName(flights, criteria, name).ToString());
                                }
                                else
                                {
                                    Console.WriteLine("No passengers found!");
                                }
                                Console.WriteLine("");
                                break;
                            case 7:
                                Console.WriteLine("Please, enter price in USD");
                                name = Console.ReadLine();
                                decimal price = InputValidation(name, 1, 99999);
                                Console.WriteLine("Arr/Depart          Date           Flight #       City      Terminal     Gate      Status");
                                Console.WriteLine("=========================================================================================");
                                foreach (Flight flight in flights)
                                {

                                    if (fm.SearchByPrice(flight, price) != null) {
                                        
                                        Console.WriteLine(fm.SearchByPrice(flight, price).ToString());
                                    }
                                }
                                Console.WriteLine("");
                                break;
                            case 8:
                                Console.WriteLine("Please, enter: 1 - for input new, 2 - for editing, 3 - for deleting flight");
                                int input = InputValidation(Console.ReadLine(), 1, 3);

                                if (input == 1) fm.Add(flights);

                                else if (input == 2)
                                {
                                    Console.WriteLine("Please, enter flight number to edit");
                                    int number = InputValidation(Console.ReadLine(), 1, 999);
                                    if(fm.SearchFlightByNumber(flights, number) != -1) fm.Edit(flights, fm.SearchFlightByNumber(flights, number));
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Please, enter flight number to delete");
                                    int number = InputValidation(Console.ReadLine(), 1, 999);
                                    if (fm.SearchFlightByNumber(flights, number) != -1) fm.Delete(flights, fm.SearchFlightByNumber(flights, number));
                                }

                                Console.WriteLine("");
                                break;
                            case 9:
                                Console.WriteLine("Please, enter: 1 - for input new, 2 - for editing, 3 - for deleting passengers");
                                input = InputValidation(Console.ReadLine(), 1, 3);

                                if (input == 1)
                                {
                                    Console.WriteLine("Please, enter flight number to add new passenger");
                                    int number = InputValidation(Console.ReadLine(), 1, 999);
                                    if (fm.SearchFlightByNumber(flights, number) != -1) pm.Add(flights, fm.SearchFlightByNumber(flights, number));

                                }
                                else if (input == 2)
                                {
                                    Console.WriteLine("Please, enter passenger's passport number for editing info");
                                    string pass = Console.ReadLine();
                                    pm.Edit(flights, pass);

                                }
                                else {
                                    Console.WriteLine("Please, enter passenger's passport number for deliting");
                                    string pass = Console.ReadLine();
                                    pm.Delete(flights, pass);

                                }


                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error" + e);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press Spacebar to exit; press any key to continue");
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);


        }

        public static int InputValidation(string input, int min, int max)
        {
            int inputNumber = -1;

            while (inputNumber == -1)
            {
                bool parsed = Int32.TryParse(input, out inputNumber);
                if (!parsed || inputNumber < min || inputNumber > max)
                {
                    Console.WriteLine(@"Please, enter valid number (digits only!) from {0} to {1}", min, max);
                    input = Console.ReadLine();
                    inputNumber = -1;
                }
            }
            return inputNumber;
        }

        public static void AllFlightsInfo()
        {
            Console.WriteLine("Arr/Depart          Date           Flight #       City      Terminal     Gate      Status");
            Console.WriteLine("=========================================================================================");
            foreach (Flight flight in flights)
            {
                if (flight != null)
                    Console.WriteLine(flight.ToString());
            }
        }

        public static void AllFlightPassengers()
        {
            Console.WriteLine("Please, enter flight number to display all passengers");
            bool found = false;
            int number = InputValidation(Console.ReadLine(), 1, 999);
            foreach (Flight flight in flights)
            {
                if (flight != null && flight.FlightNumber == number && flight.Length != 0)
                {
                    flight.PrintPassengers();
                    found = true;
                    break;
                }
            }
            if(!found) Console.WriteLine("No info found!");
        }


    }
}
