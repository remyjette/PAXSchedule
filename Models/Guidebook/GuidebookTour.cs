using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookTour
    {
        public GuidebookTour()
        {
            GuidebookTourMediatracks = new HashSet<GuidebookTourMediatrack>();
            GuidebookTourstops = new HashSet<GuidebookTourstop>();
        }

        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public string? ConcludingMessage { get; set; }
        public string? Headline { get; set; }
        public string? HeadlineDescription { get; set; }
        public long? ConclusionActionMenuitemId1 { get; set; }
        public long? ConclusionActionMenuitemId2 { get; set; }
        public bool? GpsDisabled { get; set; } = null!;

        public virtual GuidebookGuide? Guide { get; set; }
        public virtual ICollection<GuidebookTourMediatrack> GuidebookTourMediatracks { get; set; }
        public virtual ICollection<GuidebookTourstop> GuidebookTourstops { get; set; }
    }
}
