using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class ThingToLocation
    {
        public long? ThingId { get; set; }
        public long? LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Thing Thing { get; set; }
    }
}
