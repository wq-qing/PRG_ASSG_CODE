using System.Globalization;
using PRG_ASSG_CODE;
//==========================================================
// Student Number	: S10267952A S10266775
// Student Name	: Seah Qi Zhen Zoe 
// Partner Name	: Tan Wan Cheng 
//==========================================================

//Loading Flight objects (Wan Cheng)
List<Flight> flightList = new List<Flight>();
void LoadingFlights()
{
    using (StreamReader flightsFile = new StreamReader("flights.csv"))
    {
        string? flight = flightsFile.ReadLine();
        while ((flight = flightsFile.ReadLine()) != null)
        {
            string[] flightDetails = flight.Split(',');
            string flightNumber = flightDetails[0];
            string origin = flightDetails[1];
            string destination = flightDetails[2];
            DateTime expectedTime = Convert.ToDateTime(flightDetails[3]);
            string specialRequest = flightDetails[4];
            flightList.Add(new Flight(flightNumber, origin, destination, expectedTime, "On Time"));
        }
    }
}

// Basic Features (1) (Wan Cheng)
List<Airline> airlineList = new List<Airline>();
void LoadingAirlines()
{
    using (StreamReader airlinesFile = new StreamReader("airlines.csv"))
    {
        string? airline = airlinesFile.ReadLine();
        while ((airline = airlinesFile.ReadLine()) != null)
        {
            Dictionary<string, Flight> airlineFlights = new Dictionary<string, Flight>();
            string[] airlinesDetails = airline.Split(',');
            string airlineName = airlinesDetails[0];
            string airlineCode = airlinesDetails[1];
            foreach (Flight flight in flightList)
            {
                if ((flight.FlightNumber).Contains(airlineCode))
                {
                    airlineFlights[flight.FlightNumber] = flight;
                }
            }
            airlineList.Add(new Airline(airlineName, airlineCode, airlineFlights));
        }
    }
}
Dictionary<string, BoardingGate> boardingGateDictionary = new Dictionary<string, BoardingGate>();
void LoadBoardingGates()
{
    using (StreamReader boardingGatesFile = new StreamReader("boardinggates.csv"))
    {
        string? boardingGate = boardingGatesFile.ReadLine();
        while ((boardingGate = boardingGatesFile.ReadLine()) != null)
        {
            string[] boardingGateItem = boardingGate.Split(",");
            string gateName = boardingGateItem[0];
            bool supportCFFT = Convert.ToBoolean(boardingGateItem[1]);
            bool supportDDJB = Convert.ToBoolean(boardingGateItem[2]);
            bool supportLWTT = Convert.ToBoolean(boardingGateItem[3]);
            BoardingGate withoutFlight = new BoardingGate(gateName, supportCFFT, supportDDJB, supportLWTT);
            boardingGateDictionary[gateName] = withoutFlight;
        }
    }
}

// Basic Features (2) (Zoe)
List<Flight> flightslist = new List<Flight>();
void LoadFlights()
{
    using (StringReader sr = new StringReader("flights.csv"))
    {
        string? flightscontent = sr.ReadLine();
        while(( flightscontent= sr.ReadLine() )!= null)
        {
           string[] flights= flightscontent.Split(",");
            string specialRequest = flights[4];
            flightslist.Add(new Flight(Convert.ToString(flightscontent[0]), Convert.ToString(flightscontent[1]), Convert.ToString(flightscontent[2]), Convert.ToDateTime(flightscontent[3]),"On Time"));
        }

    }
}
// Basic Features (3) (Zoe)



// Basic Features (4) (Wan Cheng)
// Basic Features (5) (Zoe)
// Basic Features (6) (Zoe)
// Basic Features (7) (Wan Cheng)
// Basic Features (8) (Wan Cheng)
// Basic Features (9) (Zoe)
