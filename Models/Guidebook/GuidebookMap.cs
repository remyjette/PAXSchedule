using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_map")]
    public partial class GuidebookMap
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("import_id", TypeName = "varchar(255)")]
        public string ImportId { get; set; }
        [Column("rank")]
        public long? Rank { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("mapType", TypeName = "varchar(50)")]
        public string MapType { get; set; }
        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; }
        [Column("source", TypeName = "varchar(255)")]
        public string Source { get; set; }
        [Column("deleted", TypeName = "bool")]
        public string Deleted { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }
        [Column("width")]
        public long? Width { get; set; }
        [Column("height")]
        public long? Height { get; set; }
        [Column("levels_of_details")]
        public long? LevelsOfDetails { get; set; }
        [Column("tile_size")]
        public long? TileSize { get; set; }
    }
}
