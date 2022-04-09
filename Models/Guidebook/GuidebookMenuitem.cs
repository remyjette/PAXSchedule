using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookMenuitem
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long? GuideId { get; set; }
        public string? Name { get; set; }
        public string? Purpose { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public long? Rank { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? DisplayOptions { get; set; }

        public virtual GuidebookGuide? Guide { get; set; }
    }
}
