using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    [Table("guidebook_mapregion")]
    public partial class GuidebookMapregion
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long GuideId { get; set; }
        [Column("location_id")]
        public long? LocationId { get; set; }
        [Column("map_id")]
        public long? MapId { get; set; }
        [Column("relative_x", TypeName = "double precision")]
        public double RelativeX { get; set; }
        [Column("relative_y", TypeName = "double precision")]
        public double RelativeY { get; set; }
        [Column("relative_width", TypeName = "double precision")]
        public double RelativeWidth { get; set; }
        [Column("relative_height", TypeName = "double precision")]
        public double RelativeHeight { get; set; }
    }
}
