using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_tourstop")]
    public partial class GuidebookTourstop
    {
        public GuidebookTourstop()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedia>();
            GuidebookTourstopPoint = new HashSet<GuidebookTourstopPoint>();
            GuidebookTourstopimage = new HashSet<GuidebookTourstopimage>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("tour_id")]
        public long? TourId { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("longitude", TypeName = "double precision")]
        public double Longitude { get; set; }
        [Column("latitude", TypeName = "double precision")]
        public double Latitude { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("rank", TypeName = "double precision")]
        public double Rank { get; set; }

        [ForeignKey("TourId")]
        [InverseProperty("GuidebookTourstop")]
        public virtual GuidebookTour Tour { get; set; }
        [InverseProperty("TourStop")]
        public virtual ICollection<GuidebookTourMedia> GuidebookTourMedia { get; set; }
        [InverseProperty("Stop")]
        public virtual ICollection<GuidebookTourstopPoint> GuidebookTourstopPoint { get; set; }
        [InverseProperty("Stop")]
        public virtual ICollection<GuidebookTourstopimage> GuidebookTourstopimage { get; set; }
    }
}
