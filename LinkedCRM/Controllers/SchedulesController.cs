using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinkedCRM.Models;

namespace LinkedCRM.Controllers
{
    public class SchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schedules
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Customer).Include(s => s.Employee).Include(s => s.Lead);
            return View(schedules.ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create(int id,string customer,int emp)
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName",emp);
            //ViewBag.EmployeeId= new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", emp);
            ViewBag.LeadId = new SelectList(db.Leads, "LeadId", "Name");
            ViewData["id"] = id;
            ViewData["Cu"] = customer;
            ViewData["emp"] = emp;
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleId,CustomerId,EmployeeId,LeadId,ScheduleDateAndTime,Duration,Subject,Attendees,Description,ScheduleType,CallType,Location")] Schedule schedule,int id)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index","Default");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", schedule.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", schedule.EmployeeId);
            ViewBag.LeadId = new SelectList(db.Leads, "LeadId", "Name", schedule.LeadId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", schedule.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", schedule.EmployeeId);
            ViewBag.LeadId = new SelectList(db.Leads, "LeadId", "Name", schedule.LeadId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleId,CustomerId,EmployeeId,LeadId,ScheduleDateAndTime,Duration,Subject,Attendees,Description,ScheduleType,CallType,Location")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", schedule.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", schedule.EmployeeId);
            ViewBag.LeadId = new SelectList(db.Leads, "LeadId", "Name", schedule.LeadId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
