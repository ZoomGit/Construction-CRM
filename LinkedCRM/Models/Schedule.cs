using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{
    public enum ScheduleType { Call, Meeting }
    public enum CallType { InBound, OutBound }
    public class Schedule
    {
        //Keys
        [Key]

        public int ScheduleId { get; set; }


        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }


        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        [ForeignKey("Lead")]
        public int? LeadId { get; set; }
        //Other Properties
        public DateTime? ScheduleDateAndTime { get; set; }
        public DateTime? Duration { get; set; }
        [MaxLength(80)]
        public string Subject { get; set; }
        [MaxLength(100)]
        [DisplayFormat(NullDisplayText ="N/A")]
        public string Attendees { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public ScheduleType? ScheduleType { get; set; }
        public CallType? CallType { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }

        //Reference Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Lead Lead { get; set; }
    }
}