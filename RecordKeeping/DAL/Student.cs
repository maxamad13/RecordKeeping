using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordKeeping.DAL
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirdthDate { get; set; }
        public ICollection<AssignedToStud> AssignToStuds { get; set; }
    }
}