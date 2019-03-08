using Microsoft.EntityFrameworkCore;
using PAXScheduler.Models.Gudebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAXScheduler.Models
{
    public class Event
    {
        public string Name { get; }
        public DbContextOptions<GuidebookContext> DbContextOptions { get; set; }

        public Event(string name)
        {
            Name = name;
        }

        public Event(string name, DbContextOptions<GuidebookContext> dbContextOptions)
        {
            Name = name;
            DbContextOptions = dbContextOptions;
        }
    }
}
