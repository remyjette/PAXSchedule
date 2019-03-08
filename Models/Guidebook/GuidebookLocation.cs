using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_location")]
    public partial class GuidebookLocation
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
        [Column("mapRef")]
        public string MapRef { get; set; }
        [Column("longitude")]
        public double? Longitude { get; set; }
        [Column("latitude")]
        public double? Latitude { get; set; }
        [Column("venue_id")]
        public long? VenueId { get; set; }
        [Column("locType", TypeName = "varchar(50)")]
        public string LocType { get; set; }
        [Column("deleted", TypeName = "bool")]
        public string Deleted { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }
    }
}
