using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Airport
    {
        public Airport()
        {
            Gates = new HashSet<Gate>();
            RouteDestinationAirportNavigations = new HashSet<Route>();
            RouteFromAirportNavigations = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Iata { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Gate> Gates { get; set; }
        public virtual ICollection<Route> RouteDestinationAirportNavigations { get; set; }
        public virtual ICollection<Route> RouteFromAirportNavigations { get; set; }
    }
}
