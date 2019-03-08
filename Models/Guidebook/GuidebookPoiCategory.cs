using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_poi_category")]
    public partial class GuidebookPoiCategory
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("poi_id")]
        public long? PoiId { get; set; }
        [Column("poicategory_id")]
        public long? PoicategoryId { get; set; }
        [Column("rank", TypeName = "double precision")]
        public double Rank { get; set; }
    }
}
