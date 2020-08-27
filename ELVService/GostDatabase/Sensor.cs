using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Sensor
    {
        public Sensor()
        {
            Datastream = new HashSet<Datastream>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Encodingtype { get; set; }
        public string Metadata { get; set; }

        public virtual ICollection<Datastream> Datastream { get; set; }
    }
}
