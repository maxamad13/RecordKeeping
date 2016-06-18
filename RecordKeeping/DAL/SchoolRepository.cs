using RecordKeeping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecordKeeping.DAL
{
    public class SchoolRepository
    {
        public List<Object> StudentReport = new List<object>();
        public List<Object> FailingGrade = new List<object>();
        private SchoolContext db = new SchoolContext();

        public SchoolContext context { get; set; }

        public SchoolRepository()
        {
            // We need an instance of a Context
            context = new SchoolContext();
        }

        public SchoolRepository(SchoolContext _context)
        {
            context = _context;
        }


        //Search box for student db
        public List<Student> SearchBox(string SearchBox )
        {
            //linq statement
            var students = (from s in db.Students
                            where s.FirstName.Contains(SearchBox)
                            || s.FirstName.Contains(SearchBox)
                            select s).ToList();
            return students;
            
        }

        //display report       
        public void GetReport(int id)
        {
           
            var report = from s in db.Students
                         join a in db.AssignedToStuds on s.StudentId equals a.StudentId
                         join o in db.Assignments on a.AssignmentId equals o.AssignmentId
                         select new {s.StudentId, o.AssignmentName, a.Grade };

            foreach (var temp in report)
            {
                if (temp.StudentId==id)
                {
                    StudentReport.Add(temp);
                }
            }

            
        }

        //Shows students failed particular assignments.
        public void FailingStudents()
        {
            var report = from s in db.Students
                         join a in db.AssignedToStuds on s.StudentId equals a.StudentId
                         join o in db.Assignments on a.AssignmentId equals o.AssignmentId
                         select new { s.LastName, o.AssignmentName, a.Grade };

            foreach (var temp in report)
            {
                if (temp.Grade<70)
                {
                    FailingGrade.Add(temp);
                }

            }

        }
    }
}