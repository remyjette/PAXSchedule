using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookGuide
    {
        public GuidebookGuide()
        {
            GuidebookMenuitems = new HashSet<GuidebookMenuitem>();
            GuidebookPoicategory1s = new HashSet<GuidebookPoicategory1>();
            GuidebookSchedules = new HashSet<GuidebookSchedule>();
            GuidebookTours = new HashSet<GuidebookTour>();
            GuidebookVenues = new HashSet<GuidebookVenue>();
        }

        public long Id { get; set; }
        public long? OwnerId { get; set; }
        public long? ThemeId { get; set; }
        public string? ProductIdentifier { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public long? Rank { get; set; }
        public long? GuideVersion { get; set; }
        public long? BundleVersion { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Timezone { get; set; }
        public string? ShortName { get; set; }
        public bool? InviteOnly { get; set; }
        public bool? LoginRequired { get; set; }
        public bool? IsPreview { get; set; }
        public string? IconRaw { get; set; }
        public string? Cover { get; set; }
        public string? CogDetails { get; set; }

        public virtual ICollection<GuidebookMenuitem> GuidebookMenuitems { get; set; }
        public virtual ICollection<GuidebookPoicategory1> GuidebookPoicategory1s { get; set; }
        public virtual ICollection<GuidebookSchedule> GuidebookSchedules { get; set; }
        public virtual ICollection<GuidebookTour> GuidebookTours { get; set; }
        public virtual ICollection<GuidebookVenue> GuidebookVenues { get; set; }
    }
}
