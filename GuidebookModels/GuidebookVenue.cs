using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookVenue
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? Zoom { get; set; }
        public string LastUpdated { get; set; }

        public virtual GuidebookGuide Guide { get; set; }
    }
}
