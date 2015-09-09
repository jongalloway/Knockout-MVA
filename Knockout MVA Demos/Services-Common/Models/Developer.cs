using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services_Common.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Bug> Bugs {get; set;}
    }
}