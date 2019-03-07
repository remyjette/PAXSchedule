using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_tourstop_point")]
    public partial class GuidebookTourstopPoint
    {
        public GuidebookTourstopPoint()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedia>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("longitude", TypeName = "double precision")]
        public double Longitude { get; set; }
        [Column("latitude", TypeName = "double precision")]
        public double Latitude { get; set; }
        [Column("rank", TypeName = "double precision")]
        public double Rank { get; set; }
        [Column("stop_id")]
        public long? StopId { get; set; }

        [ForeignKey("StopId")]
        [InverseProperty("GuidebookTourstopPoint")]
        public virtual GuidebookTourstop Stop { get; set; }
        [InverseProperty("TourStopPoint")]
        public virtual ICollection<GuidebookTourMedia> GuidebookTourMedia { get; set; }
    }
}
