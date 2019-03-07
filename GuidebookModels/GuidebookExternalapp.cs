using System;
using System.Collections.Generic;

namespace PAXScheduler.GuidebookModels
{
    public partial class GuidebookExternalapp
    {
        public long Id { get; set; }
        public long? GuideId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IOsUrl { get; set; }
        public string AndroidIntentActivityPath { get; set; }
    }
}
