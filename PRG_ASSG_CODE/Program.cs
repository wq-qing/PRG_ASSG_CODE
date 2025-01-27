using System.ComponentModel.Design;
using System.Globalization;
using PRG_ASSG_CODE;
//==========================================================
// Student Number	: S10267952A S10266775
// Student Name	: Seah Qi Zhen Zoe 
// Partner Name	: Tan Wan Cheng 
//==========================================================


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
            foreach (Flight flight in flightlist)
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
List<Flight> flightlist = new List<Flight>();
void LoadFlights()
{
    using (StringReader sr = new StringReader("flights.csv"))
    {
        string? flightscontent = sr.ReadLine();
        if(( flightscontent= sr.ReadLine() )!= null)
        {
           string[] flights= flightscontent.Split(",");
            string specialRequest = flights[4];
            flightlist.Add(new Flight(Convert.ToString(flightscontent[0]), Convert.ToString(flightscontent[1]), Convert.ToString(flightscontent[2]), Convert.ToDateTime(flightscontent[3]),"On Time"));
        }
        else
        {
            Console.WriteLine("Invalid file path");
        }
       
    }
}
// Basic Features (3) (Zoe)

void ListAllFlights()
{
    if (flightlist.Count == 0)
    {
        Console.WriteLine("No flights available.");
        return;
    }

    string header = string.Format("{0,-12} {1,-20} {2,-20} {3,-20} {4}","Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");
    Console.WriteLine(new string('=', header.Length));
    Console.WriteLine(header);
    Console.WriteLine(new string('=', header.Length));

    foreach (var flight in flightlist)
    {
        Console.WriteLine(string.Format("{0,-12} {1,-20} {2,-20} {3,-20} {4:dd/M/yyyy hh:mm:ss tt}",flight.FlightNumber, AirlineName(flight.FlightNumber), flight.Origin, flight.Destination, flight.ExpectedTime));
    }
}


string AirlineName(string flightNumber)
{ 
    string airlineCode = flightNumber.Substring(0, 2);
    return airlineCode switch
    {
        "SQ" => "Singapore Airlines",
        "MH" => "Malaysia Airlines",
        "JL" => "Japan Airlines",
        "CX" => "Cathay Pacific",
        "QF" => "Qantas Airways",
        "TR" => "Scoot",
        "EK" => "Emirates",
        "BA" => "British Airways",
    };
}
// Basic Features (4) (Wan Cheng)
// Basic Features (5) (Zoe)
void BoardingGate()
{
    Console.WriteLine("Enter your flight number");

}
// Basic Features (6) (Zoe)
// Basic Features (7) (Wan Cheng)
// Basic Features (8) (Wan Cheng)
// Basic Features (9) (Zoe)
