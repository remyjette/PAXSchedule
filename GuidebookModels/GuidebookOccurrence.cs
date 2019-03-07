using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_occurrence")]
    public partial class GuidebookOccurrence
    {
        [Column("id", TypeName = "integer AUTO_INCREMENT")]
        public long Id { get; set; }
        [Column("startTime", TypeName = "datetime")]
        public string StartTime { get; set; }
        [Column("endTime", TypeName = "datetime")]
        public string EndTime { get; set; }
        [Required]
        [Column("allday", TypeName = "bool")]
        public string Allday { get; set; }
    }
}
