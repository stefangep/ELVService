using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Elevatorruntime
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string PlantRef { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public string Machine { get; set; }
        public string PlcTagName { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string FoiName { get; set; }
        public long? FoiId { get; set; }
        public long? StreamId { get; set; }
        public string TransportRunId { get; set; }
        public string ElevatorId { get; set; }
    }
}
