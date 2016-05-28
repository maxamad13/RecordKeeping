using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordKeeping.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}