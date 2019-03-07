using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookSponsor
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string ImportId { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public long? Weight { get; set; }
        public string Deleted { get; set; }
        public string LastUpdated { get; set; }
    }
}
