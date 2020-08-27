using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Thing
    {
        public Thing()
        {
            Datastream = new HashSet<Datastream>();
            Historicallocation = new HashSet<Historicallocation>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }

        public virtual ICollection<Datastream> Datastream { get; set; }
        public virtual ICollection<Historicallocation> Historicallocation { get; set; }
    }
}
