﻿using System;
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
            return false;
        }

        public double CalculateFees()
        {
            return 0;
        }

        public bool RemoveFlight(Flight flight)
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
