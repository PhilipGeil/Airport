using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Gate
    {
        public Gate()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Airport { get; set; }

        public virtual Airport AirportNavigation { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
