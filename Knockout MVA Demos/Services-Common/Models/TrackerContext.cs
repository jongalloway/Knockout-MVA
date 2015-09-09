using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services_Common.Models
{
    public class TrackerContext : DbContext
    {
        public TrackerContext() : base("TrackerContext")
        {
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}