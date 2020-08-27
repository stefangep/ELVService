using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class LocationToHistoricallocation
    {
        public long? LocationId { get; set; }
        public long? HistoricallocationId { get; set; }

        public virtual Historicallocation Historicallocation { get; set; }
        public virtual Location Location { get; set; }
    }
}
