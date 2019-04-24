using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{
    public enum InvoiceStatus { New, SendToCustomer, Paid, UnPaid }
    public class Invoice
    {
        public Invoice()
        {
            Products = new HashSet<Product>();
        }


        //Keys
        [Key]
       
        public int InvoiceId { get; set; }
       
        [ForeignKey("Customer")]
        public int? CusotmerId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public int? LeadId { get; set;  }


        //Other Properties

        [MaxLength(20)]
        public string Currency { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public decimal? Total { get; set; }
        public double? Discount { get; set; }
        [MaxLength(300)]
        public string Notes { get; set; }
        public InvoiceStatus? InvoiceStatus { get; set; }


        //Reference Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Lead Lead { get; set; }
        //Collection Navigation Properties
        public virtual ICollection<Product> Products { get; set; }

    }

}