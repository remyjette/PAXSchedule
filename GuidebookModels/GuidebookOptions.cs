using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.GuidebookModels
{
    [Table("guidebook_options")]
    public partial class GuidebookOptions
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("key", TypeName = "varchar(255)")]
        public string Key { get; set; }
        [Column("value")]
        public string Value { get; set; }
    }
}
