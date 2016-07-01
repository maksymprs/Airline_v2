using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_v2
{
    enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed,
        InFlight
    }


    class Flight
    {

        string _arrivalOrDepart; //Arrival or departure sign
        DateTime _date;
        int _flightNumber;
        string _city;
        string _terminal;
        string _gate;
        FlightStatus _status;
        Passenger[] _passengers = new Passenger[3];

        public string InOut
        {
            get { return _arrivalOrDepart; }
            set { _arrivalOrDepart = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }

        public string Gate
        {
            get { return _gate; }
            set { _gate = value; }
        }

        public FlightStatus StatusFlight
        {
            get { return _status; }
            set { _status = value; }
        }

        public Passenger this[int index]
        {
            get { return _passengers[index]; }
            set { _passengers[index] = value; }
        }

        public int Length
        {
            get { return _passengers.Length; }
        }

        public Flight() { }

        public Flight(string InOut, DateTime Date, int FlightNumber, string City, string Terminal, string Gate, FlightStatus StatusFlight)
        {
            _arrivalOrDepart = InOut;
            _date = Date;
            _flightNumber = FlightNumber;
            _city = City;
            _terminal = Terminal;
            _gate = Gate;
            _status = StatusFlight;
            Passenger[] _passengers = new Passenger[5];
        }

        public Flight Add()
        {
            Flight newFlight = new Flight();
            Console.WriteLine("Please, enter arrival or departure sign (0 - Arrival or 1 - Departure)");
            int sign = Program.InputValidation(Console.ReadLine(), 0, 1);
            if (sign == 0)
            {
                newFlight.InOut = "ARRIVAL";
            }
            else {
                newFlight.InOut = "DEPARTURE";
            }
            Console.WriteLine("Please, enter flight date in format dd.mm.yyyy hh:mm");
            newFlight.Date = DateTime.Parse(Console.ReadLine(), new CultureInfo("fr-FR", false));

            Console.WriteLine("Please, enter flight number (1-999)");
            string input = Console.ReadLine();
            int inputNumber = Program.InputValidation(input, 1, 999);
            newFlight.FlightNumber = inputNumber;

            Console.WriteLine("Please, enter flight city");
            newFlight.City = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter flight terminal");
            newFlight.Terminal = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter flight gate");
            newFlight.Gate = Console.ReadLine().ToUpper();

            Console.WriteLine(@"Please, enter flight status  0 - CheckIn, 1 - GateClosed, 2 - Arrived,
                             3 - DepartedAt, 4 - Unknown, 5 - Canceled, 
                             6 - ExpectedAt, 7 - Delayed, 8 - InFlight");
            input = Console.ReadLine();
            newFlight.StatusFlight = (FlightStatus)Program.InputValidation(input, 0, 8);

            Console.WriteLine("Please, enter number of passengers for this flight (1-5)");
            input = Console.ReadLine();
            int number = Program.InputValidation(input, 1, 5);
            Passenger[] passangers = new Passenger[number];

            return newFlight;
        }

        public Flight EditInfo(Flight someFlight)
        {

            Console.WriteLine(someFlight);
            Console.WriteLine("Do you want edit arrival/departure sign? Press Y for editing");
            string choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                if (someFlight.InOut.ToUpper().StartsWith("A"))
                {
                    someFlight.InOut = "DEPARTURE";
                    Console.WriteLine("Flight status was changed to DEPARTURE");
                }
                else {
                    someFlight.InOut = "ARRIVAL";
                    Console.WriteLine("Flight status was changed to ARRIVAL");
                }
            }

            Console.WriteLine("Do you want edit flight date? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new flight date");
                someFlight.Date = DateTime.Parse(Console.ReadLine());
            }

            Console.WriteLine("Do you want edit flight number? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new flight number (1-999)");
                string input = Console.ReadLine();
                someFlight.FlightNumber = Program.InputValidation(input, 1, 999);
            }
            Console.WriteLine("Do you want edit flight city? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new flight city");
                someFlight.City = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Do you want edit flight terminal? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new flight terminal");
                someFlight.Terminal = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Do you want edit flight gate? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new flight gate");
                someFlight.Gate = Console.ReadLine();
            }

            Console.WriteLine("Do you want edit flight status? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new flight status (0-8)");
                string input = Console.ReadLine();
                someFlight.StatusFlight = (FlightStatus)Program.InputValidation(input, 0, 8);
            }

            Console.WriteLine("Do you want edit flight passengers? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                PrintPassengers();

                Console.WriteLine("Please, enter passenger number for editing");
                choise = Console.ReadLine().ToUpper();
                int input = Program.InputValidation(choise, 1, _passengers.Length + 1);
                _passengers[input - 1] = _passengers[input - 1].EditInfo(_passengers[input - 1]);

            }
            
            return someFlight;

        }

        public void PrintPassengers()
        {
            int count = 0;
            Console.WriteLine("First name   Last name   Nationality  Passport            Birthday            Sex            Ticket info");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < _passengers.Length; i++)
            {
                if (_passengers[i] != null)
                {
                    Console.WriteLine(_passengers[i].ToString());
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("No passengers found");
        }

        public override string ToString()
        {

            return InOut + "    " + Date + "      " + FlightNumber + "          " + City + "        " + Terminal + "        " + Gate + "        " + StatusFlight;

        }

        public int SearchPassenger(string pass)
        {
            //Console.WriteLine("Please, enter passenger's passport");
            //string pass = Console.ReadLine();
            for (int i = 0; i < _passengers.Length; i++)
            {
                if (string.Equals(_passengers[i].Passport, pass))
                {
                    return i;
                }
            }
            Console.WriteLine("No match found");
            return -1;
        }


    }
}
