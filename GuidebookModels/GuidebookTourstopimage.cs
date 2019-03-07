using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookTourstopimage
    {
        public long Id { get; set; }
        public long? StopId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Rank { get; set; }

        public virtual GuidebookTourstop Stop { get; set; }
    }
}
