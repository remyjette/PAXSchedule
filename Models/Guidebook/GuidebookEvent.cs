using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    [Table("guidebook_event")]
    public partial class GuidebookEvent
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("import_id", TypeName = "varchar(255)")]
        public string ImportId { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("startTime", TypeName = "datetime")]
        public string StartTime { get; set; }
        [Column("endTime", TypeName = "datetime")]
        public string EndTime { get; set; }
        [Column("allowRating", TypeName = "bool")]
        public string AllowRating { get; set; }
        [Column("addToSchedule", TypeName = "bool")]
        public string AddToSchedule { get; set; }
        [Column("deleted", TypeName = "bool")]
        public string Deleted { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }
        [Column("locations")]
        public string Locations { get; set; }
        [Column("tracks")]
        public string Tracks { get; set; }
        [Column("rank")]
        public long? Rank { get; set; }
        [Column("links", TypeName = "longtext")]
        public string Links { get; set; }
        [Column("allday", TypeName = "bool")]
        public string Allday { get; set; }
        [Column("max_capacity")]
        public long? MaxCapacity { get; set; }
        [Column("registered_attendees")]
        public long? RegisteredAttendees { get; set; }
        [Column("waitlist", TypeName = "bool")]
        public string Waitlist { get; set; }
        [Column("require_login", TypeName = "bool")]
        public string RequireLogin { get; set; }
        [Column("registration_start_date", TypeName = "datetime")]
        public string RegistrationStartDate { get; set; }
        [Column("cog_details", TypeName = "longtext")]
        public string CogDetails { get; set; }
    }
}
