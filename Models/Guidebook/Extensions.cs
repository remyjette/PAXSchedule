using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAXSchedule.Models.Gudebook
{
    // The Guidebook SQLite Database doesn't configure Foreign Keys. As a result,
    // relationships between tables aren't created when the classes are generated
    // from the database. To avoid modifying generated classes, add the relationship
    // properties here.

    public partial class GuidebookEvent
    {
        [ForeignKey("GuideId")]
        public GuidebookGuide Guide { get; set; }

        public GuidebookEventLocation EventLocation { get; set; }

        public List<GuidebookEventScheduleTrack> ScheduleTracks { get; set; }

        public string PlaintextDescription
        {
            get
            {
                return Description
                    .Replace("<p>", "")
                    .Replace("</p>", "")
                    .Replace("<br>", "\n").Trim();
            }
        }
    }

    public partial class GuidebookEventLocation
    {
        [ForeignKey("EventId")]
        public GuidebookEvent Event { get; set; }

        [ForeignKey("LocationId")]
        public GuidebookLocation Location { get; set; }
    }

    public partial class GuidebookEventScheduleTrack
    {
        [ForeignKey("EventId")]
        public GuidebookEvent Event { get; set; }

        [ForeignKey("ScheduleId")]
        public GuidebookSchedule Schedule { get; set; }
    }
}
