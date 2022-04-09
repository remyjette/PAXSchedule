using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookLocationMetadatum
    {
        public long Id { get; set; }
        public long? LocId { get; set; }
        public long? ObjId { get; set; }
        public string? ObjType { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
    }
}
