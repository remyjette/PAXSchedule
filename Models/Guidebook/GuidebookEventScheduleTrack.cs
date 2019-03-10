using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXSchedule.Models.Gudebook
{
    [Table("guidebook_event_scheduleTrack")]
    public partial class GuidebookEventScheduleTrack
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("event_id")]
        public long? EventId { get; set; }
        [Column("schedule_id")]
        public long? ScheduleId { get; set; }
    }
}
