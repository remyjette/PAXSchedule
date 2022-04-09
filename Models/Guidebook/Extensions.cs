using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    // The Guidebook SQLite Database doesn't configure Foreign Keys. As a result,
    // relationships between tables aren't created when the classes are generated
    // from the database. To avoid modifying generated classes, add the relationship
    // properties here.

    public partial class GuidebookEvent
    {
        [ForeignKey("GuideId")]
        public GuidebookGuide Guide { get; set; } = null!;

        public GuidebookEventLocation EventLocation { get; set; } = null!;

        public List<GuidebookEventScheduleTrack> ScheduleTracks { get; set; } = null!;

        public string? PlaintextDescription
        {
            get
            {
                return Description
                    ?.Replace("<p>", "")
                    ?.Replace("</p>", "")
                    ?.Replace("<br>", "\n")?.Trim();
            }
        }
    }

    public partial class GuidebookEventLocation
    {
        [ForeignKey("EventId")]
        public GuidebookEvent Event { get; set; } = null!;

        [ForeignKey("LocationId")]
        public GuidebookLocation Location { get; set; } = null!;
    }

    public partial class GuidebookEventScheduleTrack
    {
        [ForeignKey("EventId")]
        public GuidebookEvent Event { get; set; } = null!;

        [ForeignKey("ScheduleId")]
        public GuidebookSchedule Schedule { get; set; } = null!;
    }
}
