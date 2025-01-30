using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using PRG_ASSG_CODE;
//==========================================================
// Student Number	: S10267952A S10266775
// Student Name	: Seah Qi Zhen Zoe 
// Partner Name	: Tan Wan Cheng 
//==========================================================




List<Flight> flightlist = new List<Flight>();
List<string[]> flightData = new List<string[]>();

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
void LoadFlights()
{
    using (StreamReader sr = new StreamReader("flights.csv"))
    {
        string flightscontent;
        sr.ReadLine();
        while ((flightscontent = sr.ReadLine()) != null)
        {
           string[] flight= flightscontent.Split(",");
            flightData.Add(flight); //get raw flight data 
            string flightNumber= flight[0];
            string origin= flight[1];
            string destination= flight[2];
            DateTime expectedTime = Convert.ToDateTime(flight[3]);
            string specialRequest = flight.Length > 4 ? flight[4].Trim() : "None"; 
            flightlist.Add(new Flight(flightNumber, origin,destination,expectedTime,"On Time"));
        }
        if (flightlist.Count == 0)
        {
            Console.WriteLine("No valid flights were loaded.");
        }
        else
        {
            Console.WriteLine("Flights loaded successfully.");
        }
   
}
}
// Basic Features (3) (Zoe)
string GetAirlineName(string flightNumber, List<Airline> airlineList)
{
    string airlineCode = flightNumber.Substring(0, 2);

    foreach (var airline in airlineList)
    {
        if (airline.Code == airlineCode)
        {
            return airline.Name; 
        }
    }

    return "Unknown Airline";
}

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
        string airlineName = GetAirlineName(flight.FlightNumber, airlineList);
        Console.WriteLine(string.Format(
     "{0,-12} {1,-20} {2,-20} {3,-20} {4,-20}",
     flight.FlightNumber, airlineName, flight.Origin, flight.Destination, flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm:ss tt")
 ));

    }

}
// Basic Features (4) (Wan Cheng)
// Basic Features (5) (Zoe)
void AssignBoardingGate(Dictionary<string, BoardingGate> BoardingGates, List<Flight> flightlist, List<Airline> airlineList)
{ 

    Console.WriteLine("Enter Flight Number: ");
    string flightNumber = Console.ReadLine().Trim();
    Flight flight = null;
    string specialRequest = "None";
    string AirlineName = GetAirlineName(flight.FlightNumber, airlineList);
    if (flight == null)
    {
        Console.WriteLine("Flight not found.");
        return;
    }
    else
    {
        foreach (var item in flightlist)
        {
            if (item.FlightNumber == flightNumber)
            {
                flight = item;
          
                foreach (var flightEntry in flightData)
                {
                    if (flightEntry[0] == flightNumber && flightEntry.Length >= 5)
                    {
                        specialRequest = string.IsNullOrEmpty(flightEntry[4]) ? "None" : flightEntry[4];
                        Console.WriteLine("Flight Details:");
                        Console.WriteLine($"Flight Number: {flight.FlightNumber}, Airline: {AirlineName}, Origin: {flight.Origin}, Destination: {flight.Destination}, Expected Time: {flight.ExpectedTime:dd/MM/yyyy hh:mm:ss tt}, Special Request: {specialRequest}");
                    }
                    else
                    {
                        Console.WriteLine("Flight Details:");
                        Console.WriteLine($"Flight Number: {flight.FlightNumber}, Airline: {AirlineName}, Origin: {flight.Origin}, Destination: {flight.Destination}, Expected Time: {flight.ExpectedTime:dd/MM/yyyy hh:mm:ss tt}");
                    }
                }
            }
        }
    }

    while (true)
    {
        Console.WriteLine("Enter the Boarding Gate: ");
        string boardingGate = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(boardingGate))
        {
            Console.WriteLine("Invalid Boarding Gate. Please try again.");
            continue;
        }

        if (BoardingGates.ContainsKey(boardingGate) && BoardingGates[boardingGate].Flight != null)
        {
            Console.WriteLine("The selected Boarding Gate is already assigned to another flight. Please choose a different gate.");
            continue;
        }

        if (BoardingGates.ContainsKey(boardingGate))
        {
            BoardingGates[boardingGate] = new BoardingGate(boardingGate, false, false, false, flight);
        }
        else
        {
            BoardingGates[boardingGate].Flight = flight;
        }

        Console.WriteLine("Would you like to update the flight status? (Y/N): ");
        string response = Console.ReadLine()?.Trim().ToUpper();

        if (response == "Y")
        {
            Console.WriteLine("Enter the new status (Delayed, Boarding, On Time): ");
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

        Console.WriteLine($"Successfully assigned Boarding Gate '{boardingGate}' to Flight '{flight.FlightNumber}'.");
        Console.WriteLine($"Flight Details: Flight Number: {flight.FlightNumber}, Airline: {AirlineName}, Origin: {flight.Origin}, Destination: {flight.Destination}, Expected Time: {flight.ExpectedTime:dd/MM/yyyy hh:mm:ss tt}, Special Request: {specialRequest}, Boarding Gate: {boardingGate}, Status: {flight.Status}");
        break;
    }
}
// Basic Features (6) (Zoe)
void CreateNewFlight(List<Flight> flightlist)
{
    while (true)
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine()?.Trim();

        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine()?.Trim();

        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine()?.Trim();

        Console.Write("Enter Expected Departure/Arrival Time (hh:mm tt format): ");
        string timeInput = Console.ReadLine()?.Trim();

        DateTime expectedTime;
        try
        {
            expectedTime = DateTime.ParseExact(timeInput, "h:mm tt", CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid time format. Please enter in hh:mm tt format. Try again.");
            continue;
        }

        Console.Write("Would you like to enter a Special Request Code? (Y/N): ");
        string specialRequestResponse = Console.ReadLine()?.Trim().ToUpper();
        string specialRequest = "";

        if (specialRequestResponse == "Y")
        {
            Console.Write("Enter Special Request Code: ");
            specialRequest = Console.ReadLine()?.Trim();
        }
        Flight newFlight = new Flight(flightNumber, origin, destination, expectedTime, "On Time");
        flightlist.Add(newFlight);
        using (StreamWriter sw = new StreamWriter("flights.csv" ,true))
        {
            sw.WriteLine($"{flightNumber},{origin},{destination},{expectedTime:hh:mm tt},{specialRequest}");
        }
        Console.Write("Would you like to add another flight? (Y/N): ");
        string response = Console.ReadLine()?.Trim().ToUpper();
        if (response != "Y")
        {
            Console.WriteLine("Flight(s) have been successfully added.");
            break;
        }
    }
}
// Basic Features (7) (Wan Cheng)
// Basic Features (8) (Wan Cheng)
// Basic Features (9) (Zoe)

// Basic Features (9) (Zoe)

void DisplayScheduledFlights(List<Flight> flightlist, List<Airline> airlineList, Dictionary<string, BoardingGate> BoardingGates)
{
    if (flightlist.Count == 0)
    {
        Console.WriteLine("No flights scheduled for today.");
        return;
    }

    // Sort flights by ExpectedTime
    flightlist = flightlist.OrderBy(f => f.ExpectedTime).ToList();

    string header = string.Format(
        "{0,-12} {1,-20} {2,-20} {3,-20} {4,-20} {5,-12} {6,-20} {7,-10}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Time", "Status", "Special Request", "Boarding Gate"
    );
    Console.WriteLine(new string('=', header.Length));
    Console.WriteLine(header);
    Console.WriteLine(new string('=', header.Length));

    foreach (var flight in flightlist)
    {
        string airlineName = GetAirlineName(flight.FlightNumber, airlineList);
        string specialRequest = "None";
        string boardingGate = "None";

        // Retrieve special request if applicable
        foreach (var flightEntry in flightData)
        {
            if (flightEntry[0] == flight.FlightNumber && flightEntry.Length >= 5)
            {
                specialRequest = string.IsNullOrEmpty(flightEntry[4]) ? "None" : flightEntry[4];
                break;
            }
        }

        // Retrieve assigned boarding gate if applicable
        foreach (var gate in BoardingGates)
        {
            if (gate.Value.Flight != null && gate.Value.Flight.FlightNumber == flight.FlightNumber)
            {
                boardingGate = gate.Key;
                break;
            }
        }

        Console.WriteLine(string.Format(
            "{0,-12} {1,-20} {2,-20} {3,-20} {4,-20} {5,-12} {6,-20} {7,-10}",
            flight.FlightNumber, airlineName, flight.Origin, flight.Destination,
            flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm tt"), flight.Status, specialRequest, boardingGate
        ));
    }
    Console.WriteLine(new string('=', header.Length));
}




