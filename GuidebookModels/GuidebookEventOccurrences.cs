using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookEventOccurrences
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long OccurrenceId { get; set; }
    }
}
