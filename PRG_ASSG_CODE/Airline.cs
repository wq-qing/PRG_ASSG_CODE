using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASSG_CODE
{
    internal class Airline
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }

        public Airline(string name, string code, Dictionary<string, Flight> flights)
        {
            Name = name;
            Code = code;
            Flights = flights;
        }

        public bool AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights[flight.FlightNumber] = flight;
                return true;
            }
            return false;
        }


        public double CalculateFees()
        {
            double numOfFlights = Flights.Count;
            double numOfDiscount = Math.Floor(numOfFlights / 3);
            double discuntAmount = numOfDiscount * 350;
            return discuntAmount;
        }

        public bool RemoveFlight(Flight flight)
        {
            if (Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Remove(flight.FlightNumber);
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return $"Name: {Name}, Code: {Code}, Flights: {Flights}";
        }

    }
}
