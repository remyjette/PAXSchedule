using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookPoiLocation
    {
        public long Id { get; set; }
        public long? PoiId { get; set; }
        public long? LocationId { get; set; }
    }
}
