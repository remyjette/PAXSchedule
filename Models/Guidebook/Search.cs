using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class Search
    {
        public byte[]? Title { get; set; }
        public byte[]? Label { get; set; }
        public byte[]? Description { get; set; }
        public byte[]? Locations { get; set; }
        public byte[]? Category { get; set; }
        public byte[]? Track { get; set; }
    }
}
