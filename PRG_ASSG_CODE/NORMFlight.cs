using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASSG_CODE
{
    class NORMFlight : Flight
    {
        public NORMFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "On Time"): base(flightNumber, origin, destination, expectedTime, status)
        {
        }

        public override double CalculateFees()
        {
            return 500; // Fixed fee for normal flights
        }

        public override string ToString()
        {
            return base.ToString() + $", Type: Normal Flight, Fee: {CalculateFees()}";
        }
    }

}
