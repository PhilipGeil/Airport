using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Flight
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public int GateId { get; set; }

        public virtual Gate Gate { get; set; }
        public virtual Route Route { get; set; }
    }
}
