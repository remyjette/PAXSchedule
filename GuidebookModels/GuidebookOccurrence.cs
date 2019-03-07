using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookOccurrence
    {
        public long Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Allday { get; set; }
    }
}
