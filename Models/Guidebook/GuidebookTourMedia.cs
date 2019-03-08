using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_tour_media")]
    public partial class GuidebookTourMedia
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("tour_stop_id")]
        public long TourStopId { get; set; }
        [Column("tour_stop_point_id")]
        public long? TourStopPointId { get; set; }
        [Column("track_id")]
        public long TrackId { get; set; }
        [Required]
        [Column("media", TypeName = "varchar(255)")]
        public string Media { get; set; }
        [Column("file_size")]
        public long? FileSize { get; set; }
        [Column("plays_enroute", TypeName = "bool")]
        public string PlaysEnroute { get; set; }

        [ForeignKey("TourStopId")]
        [InverseProperty("GuidebookTourMedia")]
        public virtual GuidebookTourstop TourStop { get; set; }
        [ForeignKey("TourStopPointId")]
        [InverseProperty("GuidebookTourMedia")]
        public virtual GuidebookTourstopPoint TourStopPoint { get; set; }
        [ForeignKey("TrackId")]
        [InverseProperty("GuidebookTourMedia")]
        public virtual GuidebookTourMediatrack Track { get; set; }
    }
}
