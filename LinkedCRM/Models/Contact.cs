using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{   public enum Salutation { Mr=0,Mrs=1,Ms=2,Dr=3}
    public enum Site { Corporate=0,FaceBook=1,Twitter=2}
    public enum Messenger { FaceBook=0,TeleGram=1,Viber=2,Skype=3 }
    public class Contact
    {
        //Keys
        [Key]
        public int ContactId { get; set; }


        //Other Properties
        public Salutation Salutation { get; set; }
        [Display(Name ="Contact Name")]
        public string  FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public  DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public Site Site { get; set; }

        public Messenger Messenger { get; set; }
        public  string  CompanyName { get; set; }
        public string Position { get; set; }
        public  string Street { get; set; }
        public string  Apartment { get; set; }
        public string  City { get; set; }
        public string  Region { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Comments { get; set; }


        //Collection Navigation Properties
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }
}