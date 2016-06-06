using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordKeeping.DAL
{
    public class AssignedToStud
    {
        public int AssignedToStudId { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public decimal Grade { get; set; }
    }
}