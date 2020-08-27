using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlantRef { get; set; }
        public int? ThingId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
