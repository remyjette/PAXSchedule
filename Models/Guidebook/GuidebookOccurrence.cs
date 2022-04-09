using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookOccurrence
    {
        public long Id { get; set; }
        public byte[]? StartTime { get; set; }
        public byte[]? EndTime { get; set; }
        public byte[] Allday { get; set; } = null!;
    }
}
