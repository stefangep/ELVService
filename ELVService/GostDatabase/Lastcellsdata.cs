using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Lastcellsdata
    {
        public int Id { get; set; }
        public DateTime Ts { get; set; }
        public string PlantRef { get; set; }
        public string Value { get; set; }
        public string PlcTagName { get; set; }
    }
}
