using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookSchedule
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public string? HexValue { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual GuidebookGuide? Guide { get; set; }
    }
}
