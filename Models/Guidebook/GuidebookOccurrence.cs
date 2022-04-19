using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookOccurrence
    {
        public long Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? Allday { get; set; } = null!;
    }
}
