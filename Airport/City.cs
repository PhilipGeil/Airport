using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class City
    {
        public City()
        {
            Airports = new HashSet<Airport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
    }
}
