using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class SearchMetum
    {
        public string? Type { get; set; }
        public long? ObjId { get; set; }
        public string? MapRef { get; set; }
        public string? CatOrTrack { get; set; }
        public byte[]? StartTime { get; set; }
        public byte[]? EndTime { get; set; }
        public byte[]? Allday { get; set; }
    }
}
