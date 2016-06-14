using RecordKeeping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordKeeping.DAL
{
    public class SchoolRepository
    {
        private SchoolContext db = new SchoolContext();

        public string SearchBox(string searchbox )
        {
            //linq statement
            var students = (from s in db.Students
                            where s.FirstName.Contains(searchbox)
                            || s.FirstName.Contains(searchbox)
                            select s).ToString();
            return students;
            
        }

    }
}