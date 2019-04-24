using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedCRM.Models
{
    public class Product
    {
        public Product()
        {
            Invoices = new HashSet<Invoice>();
            Quotes = new HashSet<Quote>();
        }
        //key
        [Key]
        public int ProductId { get; set; }

        //Other Properties
        public byte[] Picture { get; set; }
        public int? categoryId { get; set; }
        public int? MainCategoryId { get; set; }
        public int? CompanyId { get; set; }
        public int? UnitId { get; set; }
        public string description { get; set; }
        public double? sale_price { get; set; }
        public double? DiscountCat1 { get; set; }
        public double? DiscountCat2 { get; set; }
        public double? DiscountCat3 { get; set; }
        public double? DiscountCat4 { get; set; }
        public double? Cost_Price { get; set; }
        public double? buy_price { get; set; }
        public short? ReorderLevel { get; set; }
        public double? MaxReorderLevel { get; set; }
        public double? StartQuantity { get; set; }
        public DateTime? StartDate { get; set; }
        public double? QuantityBalance { get; set; }
        public bool Stockable { get; set; }
        public bool Taxable { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }

        //Collection Navigation Properties
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
