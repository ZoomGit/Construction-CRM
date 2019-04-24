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
    public class LeadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      
        // GET: Leads
        public ActionResult Index()
        {
            var leads = db.Leads.Include(l => l.Contact).Include(l => l.Employee).ToList();
            var ViewModel = new LeadViewModel()
            {
                LeadList = leads,
                Lead = new Lead(),
                //Employee=new Employee()
            };
           
            return View();
        }

        // GET: Leads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
           // ViewData["Meeting"] = lead.Schedules.Where(c => c.ScheduleType == ScheduleType.Meeting).ToList();

           // ViewData["Call"] = lead.Schedules.Where(c => c.ScheduleType == ScheduleType.Call).ToList();
            return View(lead);
        }

        // GET: Leads/Create
        public ActionResult Create()
        {  
           ViewBag.ConatactId = new SelectList(db.Contacts, "ContactId", "FirstName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName");
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeadId,ContactId,EmployeeId,Name,LeadStatus,LeadSource,SourceInfo,Currency,Opportunity")] Lead lead)
        { 
            if (ModelState.IsValid)
            {
                db.Leads.Add(lead);
                db.SaveChanges();
                if(lead.EmployeeId==null)
                return RedirectToAction("Index", "Default",new{Customer="Lead", Assigning = "No"});
                else
                    return RedirectToAction("Index", "Default", new { Customer = "Lead", Assigning = "Yes" });

            }

            //ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName", lead.ContactId);
            //ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", lead.EmployeeId);
            return View(lead);
        }

        // GET: Leads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName", lead.ContactId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", lead.EmployeeId);
            return View(lead);
        }

        // POST: Leads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeadId,ContactId,EmployeeId,Name,LeadStatus,LeadSource,SourceInfo,Currency,Opportunity")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "FirstName", lead.ContactId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeFirstName", lead.EmployeeId);
            return View(lead);
        }

        // GET: Leads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lead lead = db.Leads.Find(id);
            db.Leads.Remove(lead);
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
