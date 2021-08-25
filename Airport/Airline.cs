using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Airline
    {
        public Airline()
        {
            Operators = new HashSet<Operator>();
            Planes = new HashSet<Plane>();
            Routes = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Operator> Operators { get; set; }
        public virtual ICollection<Plane> Planes { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
