using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookMapregion
    {
        public long Id { get; set; }
        public long GuideId { get; set; }
        public long? LocationId { get; set; }
        public long? MapId { get; set; }
        public double RelativeX { get; set; }
        public double RelativeY { get; set; }
        public double RelativeWidth { get; set; }
        public double RelativeHeight { get; set; }
    }
}
