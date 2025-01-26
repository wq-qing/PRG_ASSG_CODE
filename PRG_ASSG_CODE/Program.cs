using System.Globalization;
using PRG_ASSG_CODE;
//==========================================================
// Student Number	: S10267952A S10266775
// Student Name	: Seah Qi Zhen Zoe 
// Partner Name	: Tan Wan Cheng 
//==========================================================
// Basic Features (1)
using (StreamReader airlinesFile = new StreamReader ("airlines.csv"))
{
    string? airline = airlinesFile.ReadLine ();
    while ((airline =  airlinesFile.ReadLine()) != null)
    {
        string[] airlinesDetails = airline.Split (',');
        string airlineName = airlinesDetails[0];
        string airlineCode = airlinesDetails[1];
        //continue only when flightList is created
    }
}
// Basic Features (2)
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

// Basic Features (3)
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

// Basic Features (4)
// Basic Features (5)
// Basic Features (6)
// Basic Features (7)
// Basic Features (8)
// Basic Features (9)
