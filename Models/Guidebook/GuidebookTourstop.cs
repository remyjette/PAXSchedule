using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookTourstop
    {
        public GuidebookTourstop()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedium>();
            GuidebookTourstopPoints = new HashSet<GuidebookTourstopPoint>();
            GuidebookTourstopimages = new HashSet<GuidebookTourstopimage>();
        }

        public long Id { get; set; }
        public long? TourId { get; set; }
        public string Name { get; set; } = null!;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Description { get; set; }
        public double Rank { get; set; }

        public virtual GuidebookTour? Tour { get; set; }
        public virtual ICollection<GuidebookTourMedium> GuidebookTourMedia { get; set; }
        public virtual ICollection<GuidebookTourstopPoint> GuidebookTourstopPoints { get; set; }
        public virtual ICollection<GuidebookTourstopimage> GuidebookTourstopimages { get; set; }
    }
}
