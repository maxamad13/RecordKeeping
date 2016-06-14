using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordKeeping.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public ICollection<AssignedToStud>AssignedToStuds { get; set; }
    }
}