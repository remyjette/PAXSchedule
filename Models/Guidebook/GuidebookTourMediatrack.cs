using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookTourMediatrack
    {
        public GuidebookTourMediatrack()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedium>();
        }

        public long Id { get; set; }
        public long TourId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }

        public virtual GuidebookTour Tour { get; set; } = null!;
        public virtual ICollection<GuidebookTourMedium> GuidebookTourMedia { get; set; }
    }
}
