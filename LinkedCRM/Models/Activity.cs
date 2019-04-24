using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{
    public enum ActivityType { SelectAcivity=0, Sms = 1, PhoneCall = 2, Email = 3, Fax = 4 }
    public class Activity
    {

        //Keys
        [Key]
        public int ActivityId { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        [ForeignKey("Lead")]
        public int? LeadId { get; set; }
        //Other Properties
        public DateTime? ActivityDate { get; set; }
        public ActivityType? ActivityType { get; set; }
        public string Notes { get; set; }
        //Navigation Properties

        public virtual Employee Employee { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Lead Lead { get; set; }



    }
}