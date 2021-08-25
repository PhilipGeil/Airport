using System;
using System.Collections.Generic;

#nullable disable

namespace Airport
{
    public partial class Plane
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public string Name { get; set; }

        public virtual Airline OwnerNavigation { get; set; }
    }
}
