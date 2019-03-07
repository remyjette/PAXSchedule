using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookMap
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string Name { get; set; }
        public string ImportId { get; set; }
        public long? Rank { get; set; }
        public string Description { get; set; }
        public string MapType { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }
        public string Deleted { get; set; }
        public string LastUpdated { get; set; }
        public long? Width { get; set; }
        public long? Height { get; set; }
        public long? LevelsOfDetails { get; set; }
        public long? TileSize { get; set; }
    }
}
