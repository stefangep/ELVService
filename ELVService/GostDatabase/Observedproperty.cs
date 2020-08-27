using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Observedproperty
    {
        public Observedproperty()
        {
            Datastream = new HashSet<Datastream>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Datastream> Datastream { get; set; }
    }
}
