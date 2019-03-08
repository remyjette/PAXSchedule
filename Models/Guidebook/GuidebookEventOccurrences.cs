using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_event_occurrences")]
    public partial class GuidebookEventOccurrences
    {
        [Column("id", TypeName = "integer AUTO_INCREMENT")]
        public long Id { get; set; }
        [Column("event_id")]
        public long EventId { get; set; }
        [Column("occurrence_id")]
        public long OccurrenceId { get; set; }
    }
}
