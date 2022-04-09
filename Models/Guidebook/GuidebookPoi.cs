using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookPoi
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string? ImportId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Label { get; set; }
        public bool? AllowRating { get; set; }
        public bool? AddToDo { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? LastUpdated { get; set; }
        public long? Rank { get; set; }
        public string? Locations { get; set; }
        public string? Categories { get; set; }
        public string? Links { get; set; }
        public string? Subimage { get; set; }
        public string? LinkImage { get; set; }
        public string? Thumbnail { get; set; }
        public string? CogDetails { get; set; }
        public string? ContactEmail { get; set; }
        public string? MeetingUrl { get; set; }
    }
}
