using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookSponsor
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string? ImportId { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public long? Weight { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? BannerImageUrl { get; set; }
        public string? BannerImageLargeUrl { get; set; }
        public string? Name { get; set; }
        public string? BannerUrl { get; set; }
        public string? Description { get; set; }
        public bool? Enabled { get; set; }
        public bool? WebsiteOnly { get; set; }
    }
}
