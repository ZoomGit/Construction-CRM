using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{
    public class LeadViewModel
    {
        public IEnumerable<LinkedCRM.Models.Lead> LeadList { get; set; }
        public Lead Lead { get; set; }
        //public ActivityType ActivityType { get; set; }
        //public ScheduleType ScheduleType { get; set; }
        public Employee Employee { get; set; }
    }
}