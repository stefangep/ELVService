using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Poi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Location { get; set; }
        public int? Thingid { get; set; }
        public string Metadata { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Geom { get; set; }
        public string OoiRef { get; set; }
    }
}
