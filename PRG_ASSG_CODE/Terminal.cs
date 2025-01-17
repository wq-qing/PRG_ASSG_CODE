using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASSG_CODE
{
    internal class Terminal
    {
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates  { get; set; }
        public Dictionary<string, double> GateFees { get; set; }

        public Terminal(string terminalName, Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> boardingGates, Dictionary<string, double> gateFees)
        {
            TerminalName = terminalName;
            Airlines = airlines;
            Flights = flights;
            BoardingGates = boardingGates;
            GateFees = gateFees;
        }

        public bool AddAirline(Airline airline)
        {

        }

        public bool AddBoardingGate(BoardingGate boardingGate)
        {

        }

        public Airline GetAirlineFromFlight(Flight flight)
        {

        }

        public void PrintAirlineFees() 
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
