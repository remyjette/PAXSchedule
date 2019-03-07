using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_tour_mediatrack")]
    public partial class GuidebookTourMediatrack
    {
        public GuidebookTourMediatrack()
        {
            GuidebookTourMedia = new HashSet<GuidebookTourMedia>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Column("tour_id")]
        public long TourId { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("image", TypeName = "varchar(255)")]
        public string Image { get; set; }

        [ForeignKey("TourId")]
        [InverseProperty("GuidebookTourMediatrack")]
        public virtual GuidebookTour Tour { get; set; }
        [InverseProperty("Track")]
        public virtual ICollection<GuidebookTourMedia> GuidebookTourMedia { get; set; }
    }
}
