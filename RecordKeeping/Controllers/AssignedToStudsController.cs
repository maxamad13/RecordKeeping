using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecordKeeping.DAL;
using RecordKeeping.Models;

namespace RecordKeeping.Controllers
{
    public class AssignedToStudsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: AssignedToStuds
        public ActionResult Index()
        {
            var assignedToStuds = db.AssignedToStuds.Include(a => a.assignmeng).Include(a => a.student);
            return View(assignedToStuds.ToList());
        }

        // GET: AssignedToStuds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedToStud assignedToStud = db.AssignedToStuds.Find(id);
            if (assignedToStud == null)
            {
                return HttpNotFound();
            }
            return View(assignedToStud);
        }

        // GET: AssignedToStuds/Create
        public ActionResult Create()
        {
            ViewBag.AssignmentId = new SelectList(db.Assignments, "AssignmentId", "AssignmentName");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: AssignedToStuds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignedToStudId,AssignmentId,StudentId,Grade")] AssignedToStud assignedToStud)
        {
            if (ModelState.IsValid)
            {
                db.AssignedToStuds.Add(assignedToStud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignmentId = new SelectList(db.Assignments, "AssignmentId", "AssignmentName", assignedToStud.AssignmentId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", assignedToStud.StudentId);
            return View(assignedToStud);
        }

        // GET: AssignedToStuds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedToStud assignedToStud = db.AssignedToStuds.Find(id);
            if (assignedToStud == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignmentId = new SelectList(db.Assignments, "AssignmentId", "AssignmentName", assignedToStud.AssignmentId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", assignedToStud.StudentId);
            return View(assignedToStud);
        }

        // POST: AssignedToStuds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignedToStudId,AssignmentId,StudentId,Grade")] AssignedToStud assignedToStud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedToStud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignmentId = new SelectList(db.Assignments, "AssignmentId", "AssignmentName", assignedToStud.AssignmentId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", assignedToStud.StudentId);
            return View(assignedToStud);
        }

        // GET: AssignedToStuds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedToStud assignedToStud = db.AssignedToStuds.Find(id);
            if (assignedToStud == null)
            {
                return HttpNotFound();
            }
            return View(assignedToStud);
        }

        // POST: AssignedToStuds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedToStud assignedToStud = db.AssignedToStuds.Find(id);
            db.AssignedToStuds.Remove(assignedToStud);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
