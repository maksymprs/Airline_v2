using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_v2
{

    public enum FlightClass
    {
        Economy,
        Business
    }

    public struct FlightTicket
    {
        private FlightClass _class;
        private decimal _price;

        public FlightClass TClass
        {
            get { return _class; }
            set { _class = value; }
        }
        public decimal TPrice
        {
            get { return _price; }
            set { _price = value; }
        }

        public FlightTicket(FlightClass Class, decimal Price)
        {
            _class = Class;
            _price = Price;
        }


        public override string ToString()
        {
            return "Ticket: class - " + _class + " price - " + _price;
        }
    }

    class Passenger
    {

        string _fName;
        string _lName;
        string _nationality;
        string _passport;
        DateTime _birthDay;
        string _sex;
        FlightTicket _ticket;

        public string FName
        {
            get { return _fName; }
            set { _fName = value; }
        }

        public string LName
        {
            get { return _lName; }
            set { _lName = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public string Passport
        {
            get { return _passport; }
            set { _passport = value; }
        }

        public DateTime Birthday
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public FlightTicket FTicket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }


        public Passenger() { }

        public Passenger(string FName, string LName, string Nationality, string Passport, DateTime Birthday, string Sex, FlightTicket FTicket)
        {
            _fName = FName;
            _lName = LName;
            _nationality = Nationality;
            _passport = Passport;
            _birthDay = Birthday;
            _sex = Sex;
            _ticket = FTicket;
        }

        public override string ToString()
        {
            return FName + "          " + LName + "          " + Nationality + "        " + Passport + "        " + Birthday.ToString() + "         " + Sex + "       " + FTicket.ToString();
        }


        public Passenger Add()
        {
            Passenger passenger = new Passenger();

            Console.WriteLine("Please, enter passenger's first name");
            passenger.FName = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter passenger's last name");
            passenger.LName = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter passenger's nationality");
            passenger.Nationality = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter passenger's passport");
            passenger.Passport = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter passenger's birthday");
            passenger.Birthday = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter passenger's sex");
            passenger.Sex = Console.ReadLine().ToUpper();

            Console.WriteLine("Please, enter passenger's ticket info");
            Console.WriteLine("Please, enter ticket class: 0 - Economy, 1 - Business");
            //FlightTicket ticket = passenger.FTicket;
            string input = Console.ReadLine();
            passenger._ticket.TClass = (FlightClass)Program.InputValidation(input, 0, 1);
            Console.WriteLine("Please, enter ticket price");
            passenger._ticket.TPrice = decimal.Parse(Console.ReadLine());

            return passenger;
        }

        public Passenger EditInfo(Passenger passenger)
        {

            Console.WriteLine(passenger);
            Console.WriteLine("Do you want edit passenger's first name? Press Y for editing");
            string choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new first name");
                passenger.FName = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Do you want edit passenger's last name? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new last name");
                passenger.LName = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Do you want edit passenger's nationality? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new nationality");
                passenger.Nationality = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Do you want edit passenger's passport? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new passport");
                passenger.Passport = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Do you want edit passenger's birthday? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new birthday");
                passenger.Birthday = DateTime.Parse(Console.ReadLine());
            }
            Console.WriteLine("Do you want edit passenger's sex? Press Y to change");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                if (passenger.Sex.ToUpper().StartsWith("F"))
                {
                    passenger.Sex = "MALE";
                    Console.WriteLine("Passenger's sex changed to MALE");
                }
                else {
                    passenger.Sex = "FEMALE";
                    Console.WriteLine("Passenger's sex changed to FEMALE");
                }
            }
            Console.WriteLine("Do you want edit passenger's ticket? Press Y for editing");
            choise = Console.ReadLine().ToUpper();
            if (string.Equals(choise, "Y"))
            {
                Console.WriteLine("Please, enter new ticket class");
                FlightTicket ticket = passenger.FTicket;
                ticket.TClass = (FlightClass)Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please, enter new ticket price");
                ticket.TPrice = decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine("Passenger's info has been changed");
            return passenger;
        }



    }

}

