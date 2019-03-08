using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_location_metadata")]
    public partial class GuidebookLocationMetadata
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("loc_id")]
        public long? LocId { get; set; }
        [Column("obj_id")]
        public long? ObjId { get; set; }
        [Column("obj_type")]
        public string ObjType { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("name", TypeName = "VARCHAR")]
        public string Name { get; set; }
    }
}
