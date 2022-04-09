using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookEvent
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string? ImportId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? AllowRating { get; set; }
        public bool? AddToSchedule { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? Locations { get; set; }
        public string? Tracks { get; set; }
        public long? Rank { get; set; }
        public string? Links { get; set; }
        public bool? Allday { get; set; }
        public long? MaxCapacity { get; set; }
        public long? RegisteredAttendees { get; set; }
        public bool? Waitlist { get; set; }
        public bool? RequireLogin { get; set; }
        public DateTime? RegistrationStartDate { get; set; }
        public string? CogDetails { get; set; }
        public bool? SessionDiscussionPostingDisabled { get; set; }
    }
}
