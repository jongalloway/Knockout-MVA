using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services_Common.Models
{
    public class Bug
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public virtual Developer AssignedTo { get; set; }
        public DateTime? DateClosed { get; set; }

        public Bug()
        {
            Status = BugStatus.New;
        }
     }

    public enum BugStatus
    {
        New, Working, Fixed, Closed 
    }
}