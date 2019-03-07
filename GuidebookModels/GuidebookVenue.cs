using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_venue")]
    public partial class GuidebookVenue
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
        [Column("street", TypeName = "varchar(255)")]
        public string Street { get; set; }
        [Column("city", TypeName = "varchar(255)")]
        public string City { get; set; }
        [Column("state", TypeName = "varchar(255)")]
        public string State { get; set; }
        [Column("zipcode", TypeName = "varchar(255)")]
        public string Zipcode { get; set; }
        [Column("longitude")]
        public double? Longitude { get; set; }
        [Column("latitude")]
        public double? Latitude { get; set; }
        [Column("zoom")]
        public double? Zoom { get; set; }
        [Column("last_updated", TypeName = "datetime")]
        public string LastUpdated { get; set; }

        [ForeignKey("GuideId")]
        [InverseProperty("GuidebookVenue")]
        public virtual GuidebookGuide Guide { get; set; }
    }
}
