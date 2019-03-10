using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    [Table("guidebook_sponsor")]
    public partial class GuidebookSponsor
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("import_id", TypeName = "varchar(255)")]
        public string ImportId { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("url", TypeName = "varchar(200)")]
        public string Url { get; set; }
        [Column("weight")]
        public long? Weight { get; set; }
        [Column("deleted", TypeName = "bool")]
        public string Deleted { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }
    }
}
