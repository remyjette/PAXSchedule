using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookEvent
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string ImportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string AllowRating { get; set; }
        public string AddToSchedule { get; set; }
        public string Deleted { get; set; }
        public string LastUpdated { get; set; }
        public string Locations { get; set; }
        public string Tracks { get; set; }
        public long? Rank { get; set; }
        public string Links { get; set; }
        public string Allday { get; set; }
        public long? MaxCapacity { get; set; }
        public long? RegisteredAttendees { get; set; }
        public string Waitlist { get; set; }
        public string RequireLogin { get; set; }
        public string RegistrationStartDate { get; set; }
        public string CogDetails { get; set; }
    }
}
