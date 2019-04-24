using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Lead
    {   //Keys
        [Key]
        public int LeadId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
         
        
        //Other Properties
        public DateTime? AssignmentDate { get; set; }
        //public Employee  AssignmentOwner { get; set; }



        //Reference Navigation Properties
        public virtual Lead
        
        public virtual Employee Employee { get; set; }

    }
}