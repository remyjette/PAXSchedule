using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_menuitem")]
    public partial class GuidebookMenuitem
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("parent_id")]
        public long? ParentId { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("purpose", TypeName = "varchar(255)")]
        public string Purpose { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("url", TypeName = "varchar(1023)")]
        public string Url { get; set; }
        [Column("rank")]
        public long? Rank { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }
        [Column("display_options")]
        public string DisplayOptions { get; set; }

        [ForeignKey("GuideId")]
        [InverseProperty("GuidebookMenuitem")]
        public virtual GuidebookGuide Guide { get; set; }
    }
}
