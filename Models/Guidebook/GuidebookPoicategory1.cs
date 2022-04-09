using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookPoicategory1
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual GuidebookGuide? Guide { get; set; }
    }
}
