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
    public class DefaultController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Default
       
        public ActionResult Index(string Customer, string Assigning, string Search)
        {

            if (Customer == "Lead" && Assigning == "Yes")
            {
                var leads = db.Leads.Where(c => c.EmployeeId != null).Include(l => l.Contact).Include(l => l.Employee).ToList();
                if (!string.IsNullOrEmpty(Search))
                    leads = leads.Where(c => c.Name.Contains(Search)).ToList();
                ViewData["_partialview"] = "_LeadView";
                var ViewModel = new LeadViewModel()
                {
                    LeadList = leads,
                    Lead = new Lead(),
                    Employee = new Employee()

                };
                
                return View(ViewModel);
            }
            else if (Customer == "Lead" && Assigning == "No")
            {
                var leads = db.Leads.Where(c => c.EmployeeId == null).Include(l => l.Contact).Include(l => l.Employee).ToList();
                ViewData["_partialview"] = "_LeadView";
                if (!string.IsNullOrEmpty(Search))
                    leads = leads.Where(c => c.Name.Contains(Search)).ToList();
                var ViewModel = new LeadViewModel()
                {
                    LeadList = leads,
                    Lead = new Lead(),
                    Employee = new Employee()

                };
                ViewData["assgining"] = Assigning;
                ViewData["Customer"] = Customer;
                return View(ViewModel);
            }
            else if (Customer == "Lead")
            {
                var leads = db.Leads.Include(l => l.Contact).Include(l => l.Employee).ToList();
                ViewData["_partialview"] = "_LeadView";
                if (!string.IsNullOrEmpty(Search))
                    leads = leads.Where(c => c.Name.Contains(Search)).ToList();
                return View(leads);
            }
            else if (Customer == "Customer" && Assigning == "No")
            {
                var customers = db.Customers.Where(c => c.EmployeeId == null).Include(c => c.Contact).Include(c => c.Employee).ToList();
                ViewData["_partialview"] = "_CustomerView";
                if (!string.IsNullOrEmpty(Search))
                    customers = customers.Where(c => c.Name.Contains(Search)).ToList();
                return View(customers);
            }
            else if (Customer == "Customer" && Assigning == "Yes")
            {
                var customers = db.Customers.Where(c => c.EmployeeId != null).Include(c => c.Contact).Include(c => c.Employee).ToList();
                ViewData["_partialview"] = "_CustomerView";
                if (!string.IsNullOrEmpty(Search))
                    customers = customers.Where(c => c.Name.Contains(Search)).ToList();

                return View(customers);
            }
            else if (Customer == "Customer")
            {
                var customers = db.Customers.Include(c => c.Contact).Include(c => c.Employee).ToList();
                ViewData["_partialview"] = "_CustomerView";
                if (!string.IsNullOrEmpty(Search))
                    customers = customers.Where(c => c.Name.Contains(Search)).ToList();

                return View(customers);
            }
            else
            {
                var leads = db.Leads.Where(c => c.EmployeeId != null).Include(l => l.Contact).Include(l => l.Employee).ToList();
                ViewData["_partialview"] = "_LeadView";
                if (!string.IsNullOrEmpty(Search))
                    leads = leads.Where(c => c.Name.Contains(Search)).ToList();
                var ViewModel = new LeadViewModel()
                {
                    LeadList = leads,
                    Lead = new Lead(),
                    Employee=new Employee()

                };
                Assigning = "Yes";
                Customer = "Lead";
                ViewData["assgining"] = Assigning;
                ViewData["Customer"] = Customer;
                return View(ViewModel);
                //ViewData["_partialview"] = "_Defaultview";

                //return View();
            }
        }
       [HttpPost]
        public ActionResult Delete(int[]LeadsToDelete)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var deleted=db.Leads.Where(x => LeadsToDelete.Contains(x.LeadId)).ToList();
                foreach(var lead in deleted)
                {
                    db.Leads.Remove(lead);
                    //db.SaveChanges();
                }
                db.SaveChanges();
            }

                return RedirectToAction("Index","Default", new { Customer = "Lead", Assigning = "Yes" });
        }
        [HttpPost]
        public ActionResult Assign(int[] LeadsToDelete,int emp)
        {
            var leads = db.Leads.Where(l => l.EmployeeId == null).Where(l => LeadsToDelete.Contains(l.LeadId)).ToList();
            foreach(var lead in leads)
            {
                lead.EmployeeId = emp;
                db.SaveChanges();
            }


            
            return RedirectToAction("Index", "Default", new { Customer ="Lead", Assigning= "Yes" });
        }
        public ActionResult ReAssign(int[] LeadsToDelete, int emp)
        {
            var leads = db.Leads.Where(l => l.EmployeeId == null).Where(l => LeadsToDelete.Contains(l.LeadId)).ToList();
            foreach (var lead in leads)
            {
                lead.EmployeeId = emp;
                db.SaveChanges();
            }



            return RedirectToAction("Index", "Default", new { Customer = "Lead", Assigning = "Yes" });
        }
    }
}