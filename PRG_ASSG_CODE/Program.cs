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
           string[] flight= flightscontent.Split(",");
            string specialRequest = flight[4];
            flightlist.Add(new Flight(Convert.ToString(flightscontent[0]), Convert.ToString(flightscontent[1]), Convert.ToString(flightscontent[2]), Convert.ToDateTime(flightscontent[3]),"On Time"));
        }
        else
        {
            Console.WriteLine("Invalid file path");
        }
       
    }
}
// Basic Features (3) (Zoe)

void ListAllFlights(List<Flight> flightlist, List<Airline> airlineList)
{
    if (flightlist.Count == 0)
    {
        Console.WriteLine("No flights available.");
        return;
    }
    string header = string.Format(
        "{0,-12} {1,-20} {2,-20} {3,-20} {4}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time"
    );
    Console.WriteLine(new string('=', header.Length));
    Console.WriteLine(header);
    Console.WriteLine(new string('=', header.Length));

    foreach (var flight in flightlist)
    {
        string AirlineCode = flight.FlightNumber.Substring(0, 2);
        string AirlineName = "";
        foreach (var airline in airlineList)
        {
            if (airline.Code == AirlineCode)
            {
                AirlineName = airline.Name;
                break;
            }
            else
            {
                Console.WriteLine("Couldn't find airline.");
            }
        }

        // Print flight details
        Console.WriteLine(string.Format(
            "{0,-12} {1,-20} {2,-20} {3,-20} {4:dd/MM/yyyy hh:mm:ss tt}",
            flight.FlightNumber, AirlineName, flight.Origin, flight.Destination, flight.ExpectedTime
        ));
    }
}


// Basic Features (4) (Wan Cheng)
// Basic Features (5) (Zoe)
void AssignBoardingGate(Dictionary<string, BoardingGate> BoardingGates)
{
    Console.Write("Enter your Flight Number : ");
    string?flightNumber = Convert.ToString(Console.ReadLine());

    if (flightNumber==null)
    {
        Console.WriteLine("Invalid flight number. Please try again.");
        return;
    }
    Flight flight = null;
    foreach (var item in flightlist)
    {
        if (item.FlightNumber == flightNumber)
        {
            flight = item;
            break;
        }
    }
    if (flight == null)
    {
        Console.WriteLine("Flight not found.");
        return;
    }



    // Display flight details
    Console.WriteLine("Flight Details:");
    Console.WriteLine($"Flight Number: {flight.FlightNumber}, Airline: {AirlineName(flight.FlightNumber)}, Origin: {flight.Origin}, Destination: {flight.Destination}, Expected Time: {flight.ExpectedTime:dd/M/yyyy hh:mm:ss tt}, Special Request: {flight.specialRequest}");

    while (true)
    {
        Console.Write("Enter the Boarding Gate: ");
        string boardingGate = Console.ReadLine()?.Trim();

        if (BoardingGates.ContainsKey(boardingGate))
        {
            Console.WriteLine("Error: The selected Boarding Gate is already assigned to another flight. Please choose a different gate.");
            continue;
        }

        // Assign the boarding gate
        BoardingGates[boardingGate] = new BoardingGates { Gate = boardingGate, AssignedFlight = flight };
        flight.BoardingGate = boardingGate;


        Console.Write("Would you like to update the flight status? (Y/N): ");
        string response = Console.ReadLine()?.Trim().ToUpper();

        if (response == "Y")
        {
            Console.Write("Enter the new status (Delayed, Boarding, On Time): ");
            string status = Console.ReadLine()?.Trim();

            if (status == "Delayed" || status == "Boarding" || status == "On Time")
            {
                flight.Status = status;
            }
            else
            {
                Console.WriteLine("Invalid status entered. Setting the default status to 'On Time'.");
                flight.Status = "On Time";
            }
        }
        else
        {
            flight.Status = "On Time";
        }

   
        Console.WriteLine($"Successfully assigned Boarding Gate '{boardingGate}' to Flight '{flightNumber}'.");
        Console.WriteLine($"Flight Details: Flight Number: {flight.FlightNumber}, Airline: {AirlineName(flight.FlightNumber)}, Origin: {flight.Origin}, Destination: {flight.Destination}, Expected Time: {flight.ExpectedTime:dd/M/yyyy hh:mm:ss tt}, Special Request: {flight.specialRequest}, Boarding Gate: {flight.BoardingGate}, Status: {flight.Status}");
        break;
    }
}
// Basic Features (6) (Zoe)

// Basic Features (7) (Wan Cheng)
// Basic Features (8) (Wan Cheng)
// Basic Features (9) (Zoe)
