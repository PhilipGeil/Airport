using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Route
    {
        public Route()
        {
            Flights = new HashSet<Flight>();
            Operators = new HashSet<Operator>();
        }

        public int Id { get; set; }
        public int FromAirport { get; set; }
        public int DestinationAirport { get; set; }
        public int Owner { get; set; }

        public virtual Airport DestinationAirportNavigation { get; set; }
        public virtual Airport FromAirportNavigation { get; set; }
        public virtual Airline OwnerNavigation { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
    }
}
