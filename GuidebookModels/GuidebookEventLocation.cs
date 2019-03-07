using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookEventLocation
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? LocationId { get; set; }
    }
}
