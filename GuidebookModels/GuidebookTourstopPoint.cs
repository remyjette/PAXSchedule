using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookTourstopPoint
    {
        public GuidebookTourstopPoint()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedia>();
        }

        public long Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Rank { get; set; }
        public long? StopId { get; set; }

        public virtual GuidebookTourstop Stop { get; set; }
        public virtual ICollection<GuidebookTourMedia> GuidebookTourMedia { get; set; }
    }
}
