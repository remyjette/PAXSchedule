﻿using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class GuidebookLocationMapInfo
    {
        public long Id { get; set; }
        public long? LocationId { get; set; }
        public long? MapId { get; set; }
    }
}
