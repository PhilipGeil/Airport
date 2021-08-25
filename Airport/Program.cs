using System;
using System.Collections.Generic;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AirportContext db = new AirportContext())
            {
                DalManager dalManager = new DalManager(db);

                List<Airport> airports = dalManager.GetAirports();
                foreach (Airport airport in airports)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{airport.Name} - {airport.Iata}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Flights:");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (Flight flight in dalManager.GetFlights(airport))
                    {
                        Console.WriteLine($"{flight.Route.FromAirportNavigation.Name} -> {flight.Route.DestinationAirportNavigation.Name} - {flight.Departure} - {Math.Round((flight.Arrival - flight.Departure).Value.TotalHours)} timer - {flight.Gate.Name}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
