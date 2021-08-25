using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Country
    {
        public Country()
        {
            Airports = new HashSet<Airport>();
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortcode { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
