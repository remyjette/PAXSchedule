using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_poi")]
    public partial class GuidebookPoi
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("import_id", TypeName = "varchar(255)")]
        public string ImportId { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("label", TypeName = "varchar(255)")]
        public string Label { get; set; }
        [Column("allowRating", TypeName = "bool")]
        public string AllowRating { get; set; }
        [Column("addToDo", TypeName = "bool")]
        public string AddToDo { get; set; }
        [Column("deleted", TypeName = "bool")]
        public string Deleted { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }
        [Column("rank")]
        public long? Rank { get; set; }
        [Column("locations")]
        public string Locations { get; set; }
        [Column("categories")]
        public string Categories { get; set; }
        [Column("links", TypeName = "longtext")]
        public string Links { get; set; }
        [Column("subimage", TypeName = "varchar(100)")]
        public string Subimage { get; set; }
        [Column("link_image", TypeName = "varchar(100)")]
        public string LinkImage { get; set; }
        [Column("thumbnail", TypeName = "varchar(100)")]
        public string Thumbnail { get; set; }
        [Column("cog_details", TypeName = "longtext")]
        public string CogDetails { get; set; }
    }
}
