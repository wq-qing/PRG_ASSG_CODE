using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASSG_CODE
{
    class CFFTFlight:Flight
    {
        public double RequestFee {  get; set; }
        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "On Time", double requestFee = 150)
            : base(flightNumber, origin, destination, expectedTime, status)
        {
            RequestFee = requestFee;
        }
        public override double CalculateFees()
        {
            return base.CalculateFees()+ RequestFee;
        }

        public override string ToString()
        {
            return base.ToString()+ $", Type: CFFT Flight, Fee: {CalculateFees()}"; 
        }
    }
}
