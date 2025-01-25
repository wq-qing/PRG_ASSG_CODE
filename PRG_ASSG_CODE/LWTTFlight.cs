using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASSG_CODE
{
    class LWTTFlight:Flight
    {
        public double requestFee {  get; set; }
        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "On Time", double requestFee = 500)
        : base(flightNumber, origin, destination, expectedTime, status)
        {
            RequestFee = requestFee;
        }
    }
}
