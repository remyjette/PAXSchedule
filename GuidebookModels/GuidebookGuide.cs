using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookGuide
    {
        public GuidebookGuide()
        {
            GuidebookMenuitem = new HashSet<GuidebookMenuitem>();
            GuidebookPoicategory1 = new HashSet<GuidebookPoicategory1>();
            GuidebookSchedule = new HashSet<GuidebookSchedule>();
            GuidebookTour = new HashSet<GuidebookTour>();
            GuidebookVenue = new HashSet<GuidebookVenue>();
        }

        public long Id { get; set; }
        public long? OwnerId { get; set; }
        public long? ThemeId { get; set; }
        public string ProductIdentifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public long? Rank { get; set; }
        public long? GuideVersion { get; set; }
        public long? BundleVersion { get; set; }
        public string UpdateDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Timezone { get; set; }
        public string ShortName { get; set; }
        public string InviteOnly { get; set; }
        public string LoginRequired { get; set; }
        public string IsPreview { get; set; }
        public string IconRaw { get; set; }
        public string Cover { get; set; }
        public string CogDetails { get; set; }

        public virtual ICollection<GuidebookMenuitem> GuidebookMenuitem { get; set; }
        public virtual ICollection<GuidebookPoicategory1> GuidebookPoicategory1 { get; set; }
        public virtual ICollection<GuidebookSchedule> GuidebookSchedule { get; set; }
        public virtual ICollection<GuidebookTour> GuidebookTour { get; set; }
        public virtual ICollection<GuidebookVenue> GuidebookVenue { get; set; }
    }
}
