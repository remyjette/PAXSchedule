using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_tourstopimage")]
    public partial class GuidebookTourstopimage
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("stop_id")]
        public long? StopId { get; set; }
        [Required]
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Column("description", TypeName = "varchar(255)")]
        public string Description { get; set; }
        [Column("rank", TypeName = "double precision")]
        public double Rank { get; set; }

        [ForeignKey("StopId")]
        [InverseProperty("GuidebookTourstopimage")]
        public virtual GuidebookTourstop Stop { get; set; }
    }
}
