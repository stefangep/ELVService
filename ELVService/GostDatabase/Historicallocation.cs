using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Historicallocation
    {
        public long Id { get; set; }
        public long? ThingId { get; set; }
        public DateTime? Time { get; set; }

        public virtual Thing Thing { get; set; }
    }
}
