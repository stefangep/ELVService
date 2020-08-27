using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Elevator
    {
        public long Id { get; set; }
        public string EquipmentId { get; set; }
        public string Name { get; set; }
        public string EgwChannel { get; set; }
        public string PlantRef { get; set; }
        public string Model { get; set; }
        public string Submodel { get; set; }
        public string Productdatamodel { get; set; }
        public string Productdataname { get; set; }
        public long? PlantId { get; set; }
        public long? PoiId { get; set; }
        public string Metadata { get; set; }
        public string DeviceId { get; set; }
    }
}
