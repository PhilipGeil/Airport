using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class DalManager
    {
        AirportContext db;

        public DalManager(AirportContext airportContext)
        {
            this.db = airportContext;
        }
        /// <summary>
        /// Get all airports
        /// </summary>
        /// <returns></returns>
        public List<Airport> GetAirports()
        {
            return db.Airports.ToList();
        }
        /// <summary>
        /// Get all flights from the selected airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public List<Flight> GetFlights(Airport airport)
        {
            return db.Flights.Include(a => a.Route).Include(a => a.Gate).Where(f => f.Route.FromAirport == airport.Id).OrderBy(a => a.Departure).ToList();
        }
    }
}
