using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class LastcellsdataSjoberg
    {
        public int Id { get; set; }
        public DateTime? Ts { get; set; }
        public string PlantRef { get; set; }
        public float? Value { get; set; }
        public string PlcTagName { get; set; }
        public int? ElevatorRuntimeId { get; set; }
        public long? FoiId { get; set; }
    }
}
