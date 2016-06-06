using RecordKeeping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecordKeeping.DAL
{
    public class SchoolContext : ApplicationDbContext 
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Assignment>Assignments { get; set; }
        public virtual DbSet<AssignedToStud> AssignedToStuds { get; set; }
    }
}