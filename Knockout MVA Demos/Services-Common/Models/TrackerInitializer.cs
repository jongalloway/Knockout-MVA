using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services_Common.Models
{
    public class TrackerInitializer: System.Data.Entity.DropCreateDatabaseAlways<TrackerContext>
    {
        protected override void Seed(TrackerContext context)
        {
            var christopher = new Developer { FirstName = "Christopher", LastName = "Harrison" };
            var jon = new Developer { FirstName = "Jon", LastName = "Galloway" };

            var developers = new List<Developer>
            {
                christopher, jon
            };

            developers.ForEach(s => context.Developers.Add(s));
            context.SaveChanges();

            var bugs = new List<Bug>
            {
                new Bug { AssignedTo = christopher, Description = "It doesn't work", DateClosed = new DateTime(2015,8,20), Status = BugStatus.Closed },
                new Bug { AssignedTo = jon, Description = "Needs more cowbell", Status = BugStatus.New}
            };

            bugs.ForEach(s => context.Bugs.Add(s));
            context.SaveChanges();
        }
    }
}