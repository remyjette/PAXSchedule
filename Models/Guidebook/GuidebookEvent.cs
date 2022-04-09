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
        public byte[]? StartTime { get; set; }
        public byte[]? EndTime { get; set; }
        public byte[]? AllowRating { get; set; }
        public byte[]? AddToSchedule { get; set; }
        public byte[]? Deleted { get; set; }
        public byte[]? LastUpdated { get; set; }
        public string? Locations { get; set; }
        public string? Tracks { get; set; }
        public long? Rank { get; set; }
        public string? Links { get; set; }
        public byte[]? Allday { get; set; }
        public long? MaxCapacity { get; set; }
        public long? RegisteredAttendees { get; set; }
        public byte[]? Waitlist { get; set; }
        public byte[]? RequireLogin { get; set; }
        public byte[]? RegistrationStartDate { get; set; }
        public string? CogDetails { get; set; }
        public byte[]? SessionDiscussionPostingDisabled { get; set; }
    }
}
