using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookPoiCategory
    {
        public long Id { get; set; }
        public long? PoiId { get; set; }
        public long? PoicategoryId { get; set; }
        public double Rank { get; set; }
    }
}
