using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    [Table("guidebook_event_location")]
    public partial class GuidebookEventLocation
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("event_id")]
        public long? EventId { get; set; }
        [Column("location_id")]
        public long? LocationId { get; set; }
    }
}
