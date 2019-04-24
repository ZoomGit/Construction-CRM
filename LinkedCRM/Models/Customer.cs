using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{
    //Emums
    
    public enum Source { FaceBook, Twitter, Recommended, Call }
    public enum CustomerType { Client = 0, Supplier = 1, Partner = 2,Competitor=3 }
    public enum Currency { EGP=0,USDollar=1,Euro=2}
    public enum Emplyees { LessThan50=0,from50To250=1,From250To500=2,Over500=3}
    public enum Industry
    {
        IT=0,
        TeleCommunication=1,
        BankingServices=2,

    }
    public class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            Quotes = new HashSet<Quote>();
            Activities = new HashSet<Activity>();
            Schedules = new HashSet<Schedule>();
        }


        //Keys
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("Contact")]
        public int? ContactId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }




        //Other Properties
        [Display(Name ="Customer Name")]
        public string Name { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }
        public string Comments { get; set; }


        public Emplyees Employees { get; set; }
        public Industry Industry { get; set; }
        public CustomerType? CustomerType { get; set; }
        public Source? Source { get; set; }

        public Currency Currency { get; set; }
        public Site WebSite { get; set; }




        // refernce Navigation Properties
        public virtual Employee Employee { get; set; }
         public virtual Contact Contact { get; set; }



        //Collection Navigation Properties
        
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }



    }

}