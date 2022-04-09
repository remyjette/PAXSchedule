using System;
using System.Collections.Generic;

namespace PAXSchedule.Models.Gudebook
{
    public partial class SearchContent
    {
        public long Docid { get; set; }
        public byte[]? C0title { get; set; }
        public byte[]? C1label { get; set; }
        public byte[]? C2description { get; set; }
        public byte[]? C3locations { get; set; }
        public byte[]? C4category { get; set; }
        public byte[]? C5track { get; set; }
    }
}
