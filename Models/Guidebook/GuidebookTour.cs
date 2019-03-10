using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    [Table("guidebook_tour")]
    public partial class GuidebookTour
    {
        public GuidebookTour()
        {
            GuidebookTourMediatrack = new HashSet<GuidebookTourMediatrack>();
            GuidebookTourstop = new HashSet<GuidebookTourstop>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("cover", TypeName = "varchar(255)")]
        public string Cover { get; set; }
        [Column("concluding_message")]
        public string ConcludingMessage { get; set; }
        [Column("headline", TypeName = "varchar(255)")]
        public string Headline { get; set; }
        [Column("headline_description")]
        public string HeadlineDescription { get; set; }
        [Column("conclusion_action_menuitem_id_1")]
        public long? ConclusionActionMenuitemId1 { get; set; }
        [Column("conclusion_action_menuitem_id_2")]
        public long? ConclusionActionMenuitemId2 { get; set; }
        [Required]
        [Column("gps_disabled", TypeName = "bool")]
        public string GpsDisabled { get; set; }

        [ForeignKey("GuideId")]
        [InverseProperty("GuidebookTour")]
        public virtual GuidebookGuide Guide { get; set; }
        [InverseProperty("Tour")]
        public virtual ICollection<GuidebookTourMediatrack> GuidebookTourMediatrack { get; set; }
        [InverseProperty("Tour")]
        public virtual ICollection<GuidebookTourstop> GuidebookTourstop { get; set; }
    }
}
