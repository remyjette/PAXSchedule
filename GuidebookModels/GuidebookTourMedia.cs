using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookTourMedia
    {
        public long Id { get; set; }
        public long TourStopId { get; set; }
        public long? TourStopPointId { get; set; }
        public long TrackId { get; set; }
        public string Media { get; set; }
        public long? FileSize { get; set; }
        public string PlaysEnroute { get; set; }

        public virtual GuidebookTourstop TourStop { get; set; }
        public virtual GuidebookTourstopPoint TourStopPoint { get; set; }
        public virtual GuidebookTourMediatrack Track { get; set; }
    }
}
