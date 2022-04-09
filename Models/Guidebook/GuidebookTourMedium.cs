using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookTourMedium
    {
        public long Id { get; set; }
        public long TourStopId { get; set; }
        public long? TourStopPointId { get; set; }
        public long TrackId { get; set; }
        public string Media { get; set; } = null!;
        public long? FileSize { get; set; }
        public byte[]? PlaysEnroute { get; set; }

        public virtual GuidebookTourstop TourStop { get; set; } = null!;
        public virtual GuidebookTourstopPoint? TourStopPoint { get; set; }
        public virtual GuidebookTourMediatrack Track { get; set; } = null!;
    }
}
