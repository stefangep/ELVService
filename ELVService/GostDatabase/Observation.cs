using System;
using System.Collections.Generic;

namespace ELVService.GostDatabase
{
    public partial class Observation
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public long? StreamId { get; set; }
        public long? FeatureofinterestId { get; set; }

        public virtual Featureofinterest Featureofinterest { get; set; }
        public virtual Datastream Stream { get; set; }
    }
}
