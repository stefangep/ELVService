using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Elevatorruntime2
    {
        public long Id { get; set; }
        public string PlantName { get; set; }
        public string PlantRef { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Machine { get; set; }
    }
}
