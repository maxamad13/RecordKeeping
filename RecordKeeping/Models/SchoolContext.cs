﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecordKeeping.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

    }
}