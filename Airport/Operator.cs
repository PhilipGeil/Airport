using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Operator
    {
        public int RouteId { get; set; }
        public int AirlineId { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual Route Route { get; set; }
    }
}
