using PRG_ASSG_CODE;

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
