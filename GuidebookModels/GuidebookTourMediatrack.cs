using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookTourMediatrack
    {
        public GuidebookTourMediatrack()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedia>();
        }

        public long Id { get; set; }
        public long TourId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual GuidebookTour Tour { get; set; }
        public virtual ICollection<GuidebookTourMedia> GuidebookTourMedia { get; set; }
    }
}
