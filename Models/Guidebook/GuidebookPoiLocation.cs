using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_poi_location")]
    public partial class GuidebookPoiLocation
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("poi_id")]
        public long? PoiId { get; set; }
        [Column("location_id")]
        public long? LocationId { get; set; }
    }
}
