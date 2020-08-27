using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class PoiProperty
    {
        public int Id { get; set; }
        public int Poiid { get; set; }
        public string Property { get; set; }
        public float? Currentvalue { get; set; }
        public string Currentvaluestring { get; set; }
        public int? Historicalvaluestream { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? Forecastvaluestream { get; set; }
        public long? Observedpropertyid { get; set; }
        public int? PoiPropertyMetaid { get; set; }
    }
}
