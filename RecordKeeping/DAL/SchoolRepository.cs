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
        public List<Object> FailingGrade = new List<object>();
       

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


        //Search box for student context
        public List<Student> SearchBox(string SearchBox )
        {
            //linq statement
            var students = (from s in context.Students
                            where s.FirstName.Contains(SearchBox)
                            || s.LastName.Contains(SearchBox)
                            select s).ToList();
            return students;
            
        }

        //display report       
        public List<object> GetReport(int id)
        {
             List<object> StudentReport = new List<object>();


        var report = from s in context.Students
                         join a in context.AssignedToStuds on s.StudentId equals a.StudentId
                         join o in context.Assignments on a.AssignmentId equals o.AssignmentId
                         select new {s.StudentId, o.AssignmentName, a.Grade };

            foreach (var temp in report)
            {
                if (temp.StudentId==id)
                {
                    StudentReport.Add(temp);
                }
            }
            return StudentReport;

            
        }

        //Shows students failed particular assignments.
        public void FailingStudents()
        {
            var report = from s in context.Students
                         join a in context.AssignedToStuds on s.StudentId equals a.StudentId
                         join o in context.Assignments on a.AssignmentId equals o.AssignmentId
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