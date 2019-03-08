using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_schedule")]
    public partial class GuidebookSchedule
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("color", TypeName = "varchar(255)")]
        public string Color { get; set; }
        [Column("hexValue", TypeName = "varchar(47)")]
        public string HexValue { get; set; }
        [Column("deleted", TypeName = "bool")]
        public string Deleted { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }

        [ForeignKey("GuideId")]
        [InverseProperty("GuidebookSchedule")]
        public virtual GuidebookGuide Guide { get; set; }
    }
}
