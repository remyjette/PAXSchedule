using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class SearchSegment
    {
        public long Blockid { get; set; }
        public byte[]? Block { get; set; }
    }
}
