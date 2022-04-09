using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookEventScheduleTrack
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? ScheduleId { get; set; }
    }
}
