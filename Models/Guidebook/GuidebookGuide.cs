using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_guide")]
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

        [Column("id")]
        public long Id { get; set; }
        [Column("owner_id")]
        public long? OwnerId { get; set; }
        [Column("theme_id")]
        public long? ThemeId { get; set; }
        [Column("productIdentifier", TypeName = "varchar(255)")]
        public string ProductIdentifier { get; set; }
        [Column("name", TypeName = "varchar(58)")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("icon", TypeName = "varchar(100)")]
        public string Icon { get; set; }
        [Column("url", TypeName = "varchar(200)")]
        public string Url { get; set; }
        [Column("rank")]
        public long? Rank { get; set; }
        [Column("guideVersion")]
        public long? GuideVersion { get; set; }
        [Column("bundleVersion")]
        public long? BundleVersion { get; set; }
        [Column("updateDate", TypeName = "datetime")]
        public string UpdateDate { get; set; }
        [Column("startDate", TypeName = "datetime")]
        public string StartDate { get; set; }
        [Column("endDate", TypeName = "datetime")]
        public string EndDate { get; set; }
        [Column("timezone", TypeName = "varchar(32)")]
        public string Timezone { get; set; }
        [Column("shortName", TypeName = "varchar(50)")]
        public string ShortName { get; set; }
        [Column("inviteOnly", TypeName = "bool")]
        public string InviteOnly { get; set; }
        [Column("loginRequired", TypeName = "bool")]
        public string LoginRequired { get; set; }
        [Column("isPreview", TypeName = "bool")]
        public string IsPreview { get; set; }
        [Column("iconRaw", TypeName = "varchar(100)")]
        public string IconRaw { get; set; }
        [Column("cover", TypeName = "varchar(100)")]
        public string Cover { get; set; }
        [Column("cog_details", TypeName = "longtext")]
        public string CogDetails { get; set; }

        [InverseProperty("Guide")]
        public virtual ICollection<GuidebookMenuitem> GuidebookMenuitem { get; set; }
        [InverseProperty("Guide")]
        public virtual ICollection<GuidebookPoicategory1> GuidebookPoicategory1 { get; set; }
        [InverseProperty("Guide")]
        public virtual ICollection<GuidebookSchedule> GuidebookSchedule { get; set; }
        [InverseProperty("Guide")]
        public virtual ICollection<GuidebookTour> GuidebookTour { get; set; }
        [InverseProperty("Guide")]
        public virtual ICollection<GuidebookVenue> GuidebookVenue { get; set; }
    }
}
