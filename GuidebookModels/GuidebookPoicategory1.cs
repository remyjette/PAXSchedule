using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_poicategory")]
    public partial class GuidebookPoicategory1
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
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }

        [ForeignKey("GuideId")]
        [InverseProperty("GuidebookPoicategory1")]
        public virtual GuidebookGuide Guide { get; set; }
    }
}
