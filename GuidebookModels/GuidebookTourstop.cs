using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookTourstop
    {
        public GuidebookTourstop()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedia>();
            GuidebookTourstopPoint = new HashSet<GuidebookTourstopPoint>();
            GuidebookTourstopimage = new HashSet<GuidebookTourstopimage>();
        }

        public long Id { get; set; }
        public long? TourId { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; }
        public double Rank { get; set; }

        public virtual GuidebookTour Tour { get; set; }
        public virtual ICollection<GuidebookTourMedia> GuidebookTourMedia { get; set; }
        public virtual ICollection<GuidebookTourstopPoint> GuidebookTourstopPoint { get; set; }
        public virtual ICollection<GuidebookTourstopimage> GuidebookTourstopimage { get; set; }
    }
}
