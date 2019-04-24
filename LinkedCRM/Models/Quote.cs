using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedCRM.Models
{
    public enum QuoteStatus { New, SendToClient, Accepted, Declined }
    public class Quote
    {
        public Quote()
        {
            Products = new HashSet<Product>();

        }

        //Keys

        [Key]
       public int QuoteId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        [ForeignKey("Lead")]
        public int? LeadId { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }


        //Other Properties
        public QuoteStatus? QuoteStatus { get; set; }
        [MaxLength(50)]
        public string currency { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ExpirationDate { get; set; }


        //Reference Navigation Properties
        public Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Lead Lead { get; set; }



        //Collection Navigation Properties
        public virtual ICollection<Product> Products { get; set; }






    }
}