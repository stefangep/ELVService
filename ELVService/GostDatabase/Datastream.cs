using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace ELVService.GostDatabase
{
    public partial class Datastream
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unitofmeasurement { get; set; }
        public int? Observationtype { get; set; }
        public NpgsqlRange<DateTime>? Phenomenontime { get; set; }
        public NpgsqlRange<DateTime>? Resulttime { get; set; }
        public long? ThingId { get; set; }
        public long? SensorId { get; set; }
        public long? ObservedpropertyId { get; set; }

        public virtual Observedproperty Observedproperty { get; set; }
        public virtual Sensor Sensor { get; set; }
        public virtual Thing Thing { get; set; }
    }
}
