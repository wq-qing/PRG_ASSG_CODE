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
List<BoardingGate> boardingGateList = new List<BoardingGate>();
void LoadingBoardingGates()
{
    using (StreamReader boardingGatesFile = new StreamReader("boardinggates.csv"))
    {
        string? boardingGate = boardingGatesFile.ReadLine();
        while ((boardingGate = boardingGatesFile.ReadLine()) != null)
        {
            string[] boardingGateDetail = boardingGate.Split(",");
            string gateName = boardingGateDetail[0];
            bool supportCFFT = Convert.ToBoolean(boardingGateDetail[1]);
            bool supportDDJB = Convert.ToBoolean(boardingGateDetail[2]);
            bool supportLWTT = Convert.ToBoolean(boardingGateDetail[3]);
            boardingGateList.Add(new BoardingGate(gateName, supportCFFT, supportDDJB, supportLWTT));
        }
    }
}

// Basic Features (2) (Zoe)
List<Flight> flights = new List<Flight>();
void LoadFlights()
{
    try
    {
        string filePath = "flights.csv";
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length >= 4)
                {
                    string flightNumber = parts[0].Trim();
                    string origin = parts[1].Trim();
                    string destination = parts[2].Trim();
                    DateTime expectedTime = DateTime.ParseExact(parts[3].Trim(), "h:mm tt", CultureInfo.InvariantCulture);
                    string specialRequest = parts.Length > 4 ? parts[4].Trim() : string.Empty;

                    flights.Add(new flights(flightNumber, origin, destination, expectedTime, "On Time", specialRequest));
                }
            }
            Console.WriteLine("Flights loaded successfully!");
        }
        else
        {
            Console.WriteLine("Error: file not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading flights: {ex.Message}");
    }
}

// Basic Features (3) (Zoe)
static void ListFlights()
{
    if (Flights.Count == 0)
    {
        Console.WriteLine("No flights available.");
        return;
    }

    Console.WriteLine("\nList of Flights:");
    foreach (var flight in flights)
    {
        Console.WriteLine(flight);
    }
}

// Basic Features (4) (Wan Cheng)
// Basic Features (5) (Zoe)
// Basic Features (6) (Zoe)
// Basic Features (7) (Wan Cheng)
// Basic Features (8) (Wan Cheng)
// Basic Features (9) (Zoe)
