using PRG_ASSG_CODE;
using System.Diagnostics.Metrics;
using System.Globalization;
//==========================================================
// Student Number	: S10267952A S10266775
// Student Name	: Seah Qi Zhen Zoe 
// Partner Name	: Tan Wan Cheng 
//==========================================================

List<Flight> flightlist = new List<Flight>();
List<string[]> flightData = new List<string[]>();

// Basic Features (1) (Wan Cheng)
List<Airline> airlineList = new List<Airline>();
void LoadAirlines()
{
    Console.WriteLine("Loading Airlines...");
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
    Console.WriteLine($"{airlineList.Count} Airlines Loaded!");
}
Dictionary<string, BoardingGate> boardingGateDictionary = new Dictionary<string, BoardingGate>();
void LoadBoardingGates()
{
    Console.WriteLine("Loading Boarding Gates...");
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
    Console.WriteLine($"{boardingGateDictionary.Count} Boarding Gates Loaded!");
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
    return "";
}


void ListAllFlights(List<Flight> flightlist, List<Airline> airlineList)
{
    if (flightlist.Count == 0)
    {
        Console.WriteLine("No flights available.");
        return;
    }
    string header = string.Format(
        "{0,-12} {1,-19} {2,-19} {3,-19} {4,23}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time"
    );
    Console.WriteLine(new string('=', header.Length));
    Console.WriteLine(header);
    Console.WriteLine(new string('=', header.Length));
    foreach (var flight in flightlist)
    {
        string airlineName = GetAirlineName(flight.FlightNumber, airlineList);
        Console.WriteLine(string.Format(
     "{0,-12} {1,-19} {2,-19} {3,-19} {4,23}",
     flight.FlightNumber, airlineName, flight.Origin, flight.Destination, flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm:ss tt")
 ));

    }

}
// Basic Features (4) (Wan Cheng)

void ListBoardingGates()
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
    Console.WriteLine("List of Boarding Gates for Changi Airport Termianl 5");
    Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
    Console.WriteLine("{0, -16}{1, -23}{2, -23}{3, -23}", "Gate Name", "DDJB", "CFFT", "LWTT");
    string supportsDDJB;
    string supportsCFFT;
    string supportsLWTT;
    foreach (BoardingGate gateDetails in boardingGateDictionary.Values)
    {
        if (gateDetails.SupportsDDJB)
        {
            supportsDDJB = "True";
        }
        else
        {
            supportsDDJB = "False";
        }
        if (gateDetails.SupportsCFFT)
        {
            supportsCFFT = "True";
        }
        else
        {
            supportsCFFT = "False";
        }
        if (gateDetails.SupportsLWTT)
        {
            supportsLWTT = "True";
        }
        else
        {
            supportsLWTT = "False";
        }
        Console.WriteLine("{0, -16}{1, -23}{2, -23}{3, -23}", gateDetails.GateName, supportsDDJB, supportsCFFT, supportsLWTT);
    }

}

// Basic Features (5) (Zoe)

void AssignBoardingGate(Dictionary<string, BoardingGate> BoardingGates, List<Flight> flightlist, List<Airline> airlineList)
{

    Console.WriteLine("Enter Flight Number: ");
    string flightNumber = Console.ReadLine().Trim().ToUpper();
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
    string AirlineName = GetAirlineName(flight.FlightNumber, airlineList);
    string specialRequest = "None";

          
               foreach (var flightEntry in flightData)
                {
                    if (flightEntry[0] == flightNumber && flightEntry.Length >= 5)
                    {
                        specialRequest = string.IsNullOrEmpty(flightEntry[4]) ? "None" : flightEntry[4];
                        break;
                    }
                    
               }
 
    Console.WriteLine("Flight Details:");
    Console.WriteLine($"Flight Number: {flight.FlightNumber}\nOrigin: {flight.Origin}\nDestination: {flight.Destination}\nExpected Time: {flight.ExpectedTime:dd/MM/yyyy hh:mm:ss tt}");
    if (!string.IsNullOrEmpty(specialRequest))
    {
        Console.WriteLine($"Special Request Code: {specialRequest}");
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
            Console.WriteLine("Enter the new status:\n1. Delayed\n2. Boarding\n3. On Time");
            string statusInput = Console.ReadLine()?.Trim();

            if (statusInput == "1")
            {
                flight.Status = "Delayed";
            }
            else if (statusInput == "2")
            {
                flight.Status = "Boarding";
            }
            else if (statusInput == "3")
            {
                flight.Status = "On Time";
            }
            else
            {
                Console.WriteLine("Invalid selection. Setting status to 'On Time'.");
                flight.Status = "On Time";
            }
        }
        Console.WriteLine($"Flight {flight.FlightNumber} has been assigned to Boarding Gate {boardingGate}!");
        break;
    }
}
// Basic Features (6) (Zoe)
void CreateNewFlight(List<Flight> flightlist)
{
    while (true)
    {
        string flightNumber;
        while (true)
        {
            try
            {
                Console.Write("Enter Flight Number (e.g., SQ 123): ");
                flightNumber = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(flightNumber) || flightNumber.Length < 6 || flightNumber[2] != ' ')
                    throw new Exception("Invalid Flight Number format.Please try again.");

                string airlineCode = flightNumber.Substring(0, 2).ToUpper();
                string flightDigits = flightNumber.Substring(3).Trim();

                if (airlineList == null || airlineList.Count == 0)
                    throw new Exception("Airline list is empty.");


                bool airlineExists = airlineList.Any(a => a.Code.Trim().Equals(airlineCode, StringComparison.OrdinalIgnoreCase));

                if (!airlineExists)
                    throw new Exception($"Invalid Airline Code '{airlineCode}'. Please enter a valid two-letter airline code.");

                if (!int.TryParse(flightDigits, out _))
                    throw new Exception("Invalid Flight Number.Please try again.");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }

        string origin;
        while (true)
        {
            try
            {
                Console.Write("Enter Origin: ");
                origin = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(origin) || origin.Any(char.IsDigit))
                    throw new Exception("Invalid Origin. Please enter a valid location.");
                break; // Valid input, exit loop
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        string destination;
        while (true)
        {
            try
            {
                Console.Write("Enter Destination: ");
                destination = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(destination) || destination.Any(char.IsDigit))
                    throw new Exception("Invalid Destination. Please enter a valid location.");
                break; // Valid input, exit loop
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        DateTime expectedTime;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
                string timeInput = Console.ReadLine()?.Trim();
                expectedTime = DateTime.ParseExact(timeInput, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time format. Please enter in 'dd/MM/yyyy HH:mm.");
            }

        }

        Console.WriteLine("Would you like to enter a Special Request Code? (Y/N): ");
        string specialRequestResponse = Console.ReadLine().Trim().ToUpper();
        string specialRequest = "";

        if (specialRequestResponse == "Y")
        {
            Console.Write("Enter Special Request Code: ");
            specialRequest = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(specialRequest))
            {
                Console.WriteLine("No special request entered.");
                specialRequest = "None";
            }
        }
        Flight newFlight = new Flight(flightNumber, origin, destination, expectedTime, "On Time");
        flightlist.Add(newFlight);
        using (StreamWriter sw = new StreamWriter("flights.csv", true))
        {
            sw.WriteLine($"{flightNumber},{origin},{destination},{expectedTime:dd/MM/yyyy hh:mm tt},{specialRequest}");
        }

        Console.WriteLine("Would you like to add another flight? (Y/N): ");
        string response = Console.ReadLine()?.Trim().ToUpper();
        if (response != "Y")
        {
            Console.WriteLine("Flight(s) have been successfully added.");
            break;
        }
    }
}

// Basic Features (7) (Wan Cheng)
Dictionary<string, Flight> airlineFlights = new Dictionary<string, Flight>();
void ListAirlines()
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
    Console.WriteLine("{0, -16}{1, -19}", "Airline Code", "Airline Name");
    foreach (Airline airline in airlineList)
    {
        Console.WriteLine("{0, -16}{1, -19}", airline.Code, airline.Name);
    }
    Console.Write("\nEnter Airline Code: ");
    string airlineCodeEntered = Console.ReadLine().ToUpper();
    Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
    bool header = false;
    bool airlinePresent = false;
    foreach (Airline airline in airlineList)
    {
        if (airline.Code.Contains(airlineCodeEntered) && header == false)
        {
            header = true;
            Console.WriteLine($"List of flights for {airline.Name}");
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
            Console.WriteLine("{0, -16}{1, -23}{2, -23}", "Flight Number", "Origin", "Destination");
        }
        foreach (string flightNumber in airline.Flights.Keys)
        {
            if (flightNumber.Contains(airlineCodeEntered))
            {
                airlinePresent = true;
                Dictionary<string, Flight> flights = airline.Flights;
                airlineFlights[flightNumber] = flights[flightNumber];
                Console.WriteLine("{0, -16}{1, -23}{2, -23}", flights[flightNumber].FlightNumber, flights[flightNumber].Origin, flights[flightNumber].Destination);
            }
        }
    }
    if (airlinePresent == false)
    {
        Console.WriteLine("Invalid Airline Code Entered.");
    }
}
void ListFlightDetails()
{ 
    Console.Write("\nEnter the Flight Number: ");
    string flightNumberEntered = Console.ReadLine().ToUpper();
    string airlineName = "Not Available";
    foreach (string flightNumber in airlineFlights.Keys)
    {
        if (flightNumberEntered == flightNumber)
        {
            foreach (Airline airline in airlineList)
            {
                if (flightNumber.Contains(airline.Code))
                {
                    airlineName = airline.Name;
                    break;
                }
            }
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
            Console.WriteLine($"Flight Deails for Flight Number {flightNumber}");
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 45)));
            Console.WriteLine("{0, -32}: {1, -16}", "Flight Number", flightNumber);
            Console.WriteLine("{0, -32}: {1, -16}", "Airline Name", airlineName);
            Console.WriteLine("{0, -32}: {1, -16}", "Origin", airlineFlights[flightNumber].Origin);
            Console.WriteLine("{0, -32}: {1, -16}", "Destination", airlineFlights[flightNumber].Destination);
            Console.WriteLine("{0, -32}: {1, -16}", "Expected Departure/Arrival Time", airlineFlights[flightNumber].ExpectedTime);
            break;
        }
    }
    if (airlineName == "Not Available")
    {
        Console.WriteLine("Invalid Flight Number Entered.");
    }
}

// Basic Features (8) (Wan Cheng)
Dictionary<string, List<string>> flightDictWithCode = new Dictionary<string, List<string>>();
void ModifyFlightDetails()
{
    Console.WriteLine("Choose an existing Flight to modify or delete:");
    string flightNumberEntered = Console.ReadLine().ToUpper();
    foreach (string flightNumber in airlineFlights.Keys)
    {
        if (flightNumberEntered == flightNumber)
        {
            using (StreamReader flight = new StreamReader("flights.csv"))
            {
                string flightLine;
                flight.ReadLine();
                while ((flightLine = flight.ReadLine()) != null)
                {
                    List<string> flightItems = new List<string>();
                    string[] flightDetails = flightLine.Split(',');
                    flightItems.Add(flightDetails[0]);
                    flightItems.Add(flightDetails[1]);
                    flightItems.Add(flightDetails[2]);
                    flightItems.Add(flightDetails[3]);
                    flightItems.Add(flightDetails[4]);
                    flightDictWithCode[flightDetails[0]] = flightItems;
                }
                break;
            }
        }
    }
    Console.WriteLine("1. Modify Flight" +
        "\n2. Delete Flight");
    Console.WriteLine("Choose an option:");
    string option = Console.ReadLine();
    switch (option)
    {    
        case "1":
            Console.WriteLine("1. Modify Basic Information"+
            "\n2. Modify Status" +
            "\n3. Modify Special Request Code" +
            "\n4. Modify Boarding Gate");
            Console.WriteLine("Choose an option:");
            string furtherOption = Console.ReadLine();
            switch (furtherOption)
            {
                case "1":
                    foreach (string flightNumber in flightDictWithCode.Keys)
                    {
                        if (flightNumberEntered == flightNumber)
                        {
                            Console.Write("Enter new Origin: ");
                            string origin = Console.ReadLine();
                            airlineFlights[flightNumberEntered].Origin = origin;
                            flightDictWithCode[flightNumber][1] = origin;
                            Console.Write("Enter new Destination: ");
                            string destination = Console.ReadLine();
                            airlineFlights[flightNumberEntered].Destination = destination;
                            flightDictWithCode[flightNumber][2] = destination;
                            Console.Write("Enter new Expected Departure/ Arrival Time(dd / mm / yyyy hh: mm): ");
                            string expectedTime = Console.ReadLine();
                            airlineFlights[flightNumberEntered].ExpectedTime = Convert.ToDateTime(expectedTime);
                            flightDictWithCode[flightNumber][3] = expectedTime;
                            Console.WriteLine("Flight Updated!");
                            break;
                        }
                    }
                    break;
                case "2":
                    Console.Write("Enter new Status: ");
                    airlineFlights[flightNumberEntered].Status = Console.ReadLine();
                    Console.WriteLine("Flight Updated!");
                    break;
                case "3":
                    foreach (string flightNumber in flightDictWithCode.Keys)
                    {
                        if (flightNumberEntered == flightNumber)
                        {
                            Console.Write("Enter new Special Request Code: ");
                            string specialRequestCode = Console.ReadLine().ToUpper();
                            flightDictWithCode[flightNumber][4] = specialRequestCode;
                            break;
                        }
                    }
                    Console.WriteLine("Flight Updated!");
                    break;
                case "4":
                    Console.Write("Enter new Boarding Gate: ");
                    string boardingGateEntered = Console.ReadLine().ToUpper();
                    foreach (string gateName in boardingGateDictionary.Keys)
                    {
                        if (boardingGateEntered == gateName)
                        {
                            foreach (Airline airline in airlineList)
                            {
                                if (airline.Flights.ContainsKey(flightNumberEntered))
                                {
                                    boardingGateDictionary[gateName].Flight = airlineFlights[flightNumberEntered];
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Flight Updated!");
                    break;
            }
            break;
        case "2":
            Console.WriteLine("Are you sure you want to delete this flight? (Y/N)");
            string confirm = Console.ReadLine().ToUpper();

            if (confirm == "Y")
            {
                Flight flight = null;
                foreach (Airline airline in airlineList)
                {
                    if (airline.Flights.ContainsKey(flightNumberEntered))
                    {
                        flight = airline.Flights[flightNumberEntered];
                        airline.Flights.Remove(flightNumberEntered);
                        airlineFlights.Remove(flightNumberEntered);
                        break;
                    }
                }
                flightlist.Remove(flight);
                flightDictWithCode.Remove(flightNumberEntered);
                boardingGateDictionary.Remove(flightNumberEntered);

                Console.WriteLine("Flight deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
            break;
        default:
            Console.WriteLine("Invalid Input.");
            break;
    }
}


// Basic Features (9) (Zoe)
void DisplayScheduledFlights(List<Flight> flightlist, List<Airline> airlineList, Dictionary<string, BoardingGate> BoardingGates)
{
    if (flightlist.Count == 0)
    {
        Console.WriteLine("No flights scheduled for today.");
        return;
    }

    flightlist.Sort((f1, f2) => f1.ExpectedTime.CompareTo(f2.ExpectedTime));

    string header = string.Format(
        "{0,-12} {1,-20} {2,-20} {3,-20} {4,-22} {5,-12} {6,-20} {7,-15}",
        "Flight No", "Airline Name", "Origin", "Destination", "Expected Time", "Status", "Special Request", "Boarding Gate"
    );

    Console.WriteLine(new string('=', header.Length));
    Console.WriteLine(header);
    Console.WriteLine(new string('=', header.Length));


    foreach (var flight in flightlist)
    {
        string airlineName = GetAirlineName(flight.FlightNumber, airlineList);
        string specialRequest = "";
        string boardingGate = "Not Assigned";
        foreach (var flightEntry in flightData)
        {
            if (flightEntry[0] == flight.FlightNumber && flightEntry.Length >= 5)
            {
                specialRequest = string.IsNullOrWhiteSpace(flightEntry[4]) ? "" : flightEntry[4];
                break;
            }
        }

        foreach (var gate in BoardingGates)
        {
            if (gate.Value.Flight != null && gate.Value.Flight.FlightNumber == flight.FlightNumber)
            {
                boardingGate = gate.Key;
                break;
            }
        }

        Console.WriteLine(string.Format(
            "{0,-12} {1,-20} {2,-20} {3,-20} {4,-22} {5,-12} {6,-20} {7,-15}",
            flight.FlightNumber,
            string.IsNullOrWhiteSpace(airlineName) ? "Unknown Airline" : airlineName,
            flight.Origin,
            flight.Destination,
            flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm tt"),
            flight.Status,
            string.IsNullOrWhiteSpace(specialRequest) ? "" : specialRequest,
            boardingGate
        ));
    }

    Console.WriteLine(new string('=', header.Length));
}


int CompareFlightsByExpectedTime(Flight f1, Flight f2)
{
    return f1.ExpectedTime.CompareTo(f2.ExpectedTime);
}


//Additional Feature A (Wan Cheng)
Queue <Flight> unassignedFlights = new Queue<Flight>();
List<BoardingGate> unassignedGates = new List<BoardingGate>();
void ProcessAllUnassignedFlights()
{
    foreach (var flight in flightlist)
    {
        if (!boardingGateDictionary.Values.Select(gate => gate.Flight?.FlightNumber).Contains(flight.FlightNumber))
        {
            unassignedFlights.Enqueue(flight);
        }
    }

    foreach (BoardingGate boardingGate in boardingGateDictionary.Values)
    {
        if (boardingGate.Flight == null)
        {
            unassignedGates.Add(boardingGate);
        }
    }
    int unassignedflights = unassignedFlights.Count;
    int unassignedgates = unassignedGates.Count;
    Console.WriteLine($"\nTotal number of unassigned flights: {unassignedflights}");
    Console.WriteLine($"Total number of unassigned boarding gates: {unassignedgates}");

    int processedFlights = 0;
    int processedGates = 0;

    while (unassignedFlights.Count > 0 && unassignedGates.Count > 0)
    {
        Flight flight = unassignedFlights.Dequeue();
        BoardingGate? gateChosen = null;

        string specialRequestCode = flightDictWithCode[flight.FlightNumber][4];
        if (specialRequestCode != "")
        {
            gateChosen = unassignedGates.FirstOrDefault(gate => specialRequestCode switch
            {
                "DDJB" => gate.SupportsDDJB,
                "CFFT" => gate.SupportsCFFT,
                "LWTT" => gate.SupportsLWTT,
                _ => false
            });
        }

        if (gateChosen == null)
        {
            gateChosen = unassignedGates.FirstOrDefault(gate => specialRequestCode switch
            {
                "DDJB" => !gate.SupportsDDJB,
                "CFFT" => !gate.SupportsCFFT,
                "LWTT" => !gate.SupportsLWTT,
                _ => true
            });
        }

        if (gateChosen != null)
        {
            gateChosen.Flight = flight;
            unassignedGates.Remove(gateChosen);
            processedFlights++;
            processedGates++;
        }
    }

    Console.WriteLine($"\nTotal flights processed and assigned: {processedFlights}");
    Console.WriteLine($"Total gates processed and assigned: {processedGates}");
    Console.WriteLine();
    int totalFlights = flightlist.Count;
    int totalGates = boardingGateDictionary.Count;
    double processedFlightsOverUnassignedFlight = (processedFlights / unassignedflights) * 100;
    double processedGatesOverUnassigneGates = (processedGates / unassignedgates) * 100;
    Console.WriteLine($"Percentage of Flights processed automatically over those already assigned: {processedFlightsOverUnassignedFlight:0.00}%");
    Console.WriteLine($"Percentage of Gates processed automatically over those already assigned: {processedGatesOverUnassigneGates:0.00}%");
}

//Additional Feature B  (Zoe)

void DisplayTotalFeesPerAirline(List<Flight> flightlist, List<Airline> airlineList, Dictionary<string, BoardingGate> boardingGates)
{

    var unassignedFlights = flightlist.Where(f => !boardingGates.Values.Any(bg => bg.Flight != null && bg.Flight.FlightNumber == f.FlightNumber)).ToList();

    if (unassignedFlights.Count > 0)
    {
        Console.WriteLine("\nThe following flights have not been assigned a boarding gate:");
        foreach (var flight in unassignedFlights)
        {
            Console.WriteLine($"- {flight.FlightNumber} ({GetAirlineName(flight.FlightNumber, airlineList)})");
        }
        Console.WriteLine("\nPlease assign boarding gates to all flights.\n");
        return;
    }

    Console.WriteLine("\n===============================");
    Console.WriteLine("  Total Fees per Airline for Today");
    Console.WriteLine("===============================");

    double totalAirlineFees = 0;
    double totalDiscounts = 0;

    foreach (var airline in airlineList)
    {
        double airlineSubtotal = 0;
        double airlineDiscounts = 0;

        var airlineFlights = flightlist.Where(f => f.FlightNumber.StartsWith(airline.Code)).ToList();

        if (airlineFlights.Count == 0) continue;

        Console.WriteLine($"\nAirline: {airline.Name} ({airline.Code})");
        Console.WriteLine("---------------------------------------");

        foreach (var flight in airlineFlights)
        {
            double flightFee = 300;

            if (flight.Origin == "Singapore (SIN)")
            {
                flightFee += 800;
            }
            else if (flight.Destination == "Singapore (SIN)")
            {
                flightFee += 500;
            }

            string specialRequest = "None";
            foreach (var flightEntry in flightData)
            {
                if (flightEntry[0] == flight.FlightNumber && flightEntry.Length >= 5)
                {
                    specialRequest = flightEntry[4].Trim();
                    break;
                }
            }

            if (specialRequest == "CFFT")
            {
                flightFee += 150;
            }
            else if (specialRequest == "DDJB")
            {
                flightFee += 300;
            }
            else if (specialRequest == "LWTT")
            {
                flightFee += 500;
            }

            Console.WriteLine($"Flight {flight.FlightNumber} - Fee: ${flightFee}");

            airlineSubtotal += flightFee;
        }


        if (airlineFlights.Count >= 5)
        {
            airlineDiscounts = airlineSubtotal * 0.10;
        }

        double finalFee = airlineSubtotal - airlineDiscounts;

        Console.WriteLine($"\nSubtotal: ${airlineSubtotal}");
        Console.WriteLine($"Discounts: -${airlineDiscounts}");
        Console.WriteLine($"Final Fee to be Collected: ${finalFee}");
        Console.WriteLine("---------------------------------------");

        totalAirlineFees += airlineSubtotal;
        totalDiscounts += airlineDiscounts;
    }

    double totalFinalFees = totalAirlineFees - totalDiscounts;
    double discountPercentage = (totalDiscounts / totalAirlineFees) * 100;

    Console.WriteLine("\n===============================");
    Console.WriteLine(" Total Sum");
    Console.WriteLine("===============================");
    Console.WriteLine($"Total Airline Fees (Before Discounts): ${totalAirlineFees}");
    Console.WriteLine($"Total Discounts Applied: -${totalDiscounts}");
    Console.WriteLine($"Total Fees Collected: ${totalFinalFees}");
    Console.WriteLine($"Discount Percentage: {discountPercentage:F2}%");
    Console.WriteLine("===============================");
}

void DisplayMenu()
{
    LoadFlights();
    LoadAirlines();
    LoadBoardingGates();
    while (true)
    {
        Console.WriteLine("\n=============================================");
        Console.WriteLine("   Welcome to Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        Console.WriteLine("1. List All Flights");
        Console.WriteLine("2. List Boarding Gates");
        Console.WriteLine("3. Assign a Boarding Gate to a Flight");
        Console.WriteLine("4. Create Flight");
        Console.WriteLine("5. Display Airline Flights");
        Console.WriteLine("6. Modify Flight Details");
        Console.WriteLine("7. Display Flight Schedule");
        Console.WriteLine("8. Bulk Process Unassigned Flights");
        Console.WriteLine("9. Display the total fee per airline for the day");
        Console.WriteLine("0. Exit");
        Console.WriteLine("\nPlease enter your option: ");

        string choice = Console.ReadLine()?.Trim();

        switch (choice)
        {
            case "1":
                ListAllFlights(flightlist, airlineList);
                break;

            case "2":
                ListBoardingGates();
                break;

            case "3":
                AssignBoardingGate(boardingGateDictionary, flightlist, airlineList);
                break;

            case "4":
                CreateNewFlight(flightlist);
                break;

            case "5":
                ListAirlines();
                ListFlightDetails();
                break;

            case "6":
                ListAirlines();
                ModifyFlightDetails();
                break;

            case "7":
                DisplayScheduledFlights(flightlist, airlineList, boardingGateDictionary);
                break;

            case "8":
                ProcessAllUnassignedFlights();
                break;

            case "9":
                DisplayTotalFeesPerAirline(flightlist, airlineList, boardingGateDictionary);
                break;

            case "0":
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                break;
        }
    }
}


DisplayMenu();