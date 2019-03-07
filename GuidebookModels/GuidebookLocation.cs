using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookLocation
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string ImportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string MapRef { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public long? VenueId { get; set; }
        public string LocType { get; set; }
        public string Deleted { get; set; }
        public string LastUpdated { get; set; }
    }
}
