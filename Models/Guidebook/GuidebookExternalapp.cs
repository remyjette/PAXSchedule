using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAXScheduler.Models.Gudebook
{
    [Table("guidebook_externalapp")]
    public partial class GuidebookExternalapp
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("guide_id")]
        public long? GuideId { get; set; }
        [Column("name", TypeName = "CHAR")]
        public string Name { get; set; }
        [Column("url", TypeName = "CHAR")]
        public string Url { get; set; }
        [Column("iOS_url", TypeName = "CHAR")]
        public string IOsUrl { get; set; }
        [Column("android_intent_activity_path", TypeName = "CHAR")]
        public string AndroidIntentActivityPath { get; set; }
    }
}
