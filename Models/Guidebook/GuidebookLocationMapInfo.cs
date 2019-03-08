using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_location_mapInfo")]
    public partial class GuidebookLocationMapInfo
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("location_id")]
        public long? LocationId { get; set; }
        [Column("map_id")]
        public long? MapId { get; set; }
    }
}
