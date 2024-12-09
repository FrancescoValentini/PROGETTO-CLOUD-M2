using AirplanesAPI.Models;
using AirplanesAPI.Service;

namespace APITest
{
    public static class APITest
    {
         public static void Main(string[] args)
        {
            // Display the number of command line arguments.
            Console.WriteLine("Hello world");

            Ac Response = AirplanesAPIService.FindAircraftByCallsign("TYPHN330");
            Console.WriteLine(Response.Desc);

            Ac Response1 = AirplanesAPIService.FindAircraftByICAOCode("43c79c");
            Console.WriteLine(Response1.Desc);


        }
    }
}
