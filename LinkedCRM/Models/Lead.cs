using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{    public enum LeadStatus { UnAssigned=0,InProgress=1,Processed=2,JunkLead=3}
    public enum LeadSource { Call=0,Email=1,Website=2,Avertising=3,ByRecommended=4}
    public class Lead
    {  
        //Keys
        [Key]
        public int LeadId { get; set; }
        [ForeignKey("Contact")]
        [DisplayFormat(NullDisplayText = "Not Assigned")]
        public int? ContactId { get; set; }
        
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        //Other Properties
        [Display(Name="Lead Name")]
        public string Name { get; set; }
        [Display(Name = "Lead Status")]
        public LeadStatus? LeadStatus { get; set; }
        [Display(Name = "Lead Source")]
        public LeadSource? LeadSource { get; set; }
        [Display(Name = "Source Information")]
        public string SourceInfo { get; set; }
        public string Currency { get; set; }
        public string Opportunity { get; set; }



        //Refernce Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Contact Contact { get; set; }

        //Collection Navigation Properties
        
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        



    }
}