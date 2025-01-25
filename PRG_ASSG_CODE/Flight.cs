using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASSG_CODE
{
    class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "On Time")
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
        }

        public virtual double CalculateFees()
        {
            return 500; 
        }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, Origin: {Origin}, Destination: {Destination}, Expected Time: {ExpectedTime}, Status: {Status}";
        }
    }

}
