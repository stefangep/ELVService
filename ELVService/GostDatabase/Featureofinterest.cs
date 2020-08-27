using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Featureofinterest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Encodingtype { get; set; }
        public string Geojson { get; set; }
        public long? OriginalLocationId { get; set; }
    }
}
