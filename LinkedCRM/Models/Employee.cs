using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedCRM.Models
{
    public class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
            Activities = new HashSet<Activity>();
            Quotes = new HashSet<Quote>();
            Schedules = new HashSet<Schedule>();
            Invoices = new HashSet<Invoice>();
        }

        //Keys
        public int EmployeeId { get; set; }

        //Other Properties
        [Display(Name ="HR Code")]
        public int? EnrollNo { get; set; }
        public int? HRCode { get; set; }
        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public string EmployeeFirstName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Employee Arabic Name")]
        public string EmployeeArabicName { get; set; }
        [MaxLength(50)]
        public string NationalId { get; set; }
        [MaxLength(50)]
        public string PassportId { get; set; }
        [MaxLength(200)]
        public string AddressLine1 { get; set; }
        [MaxLength(200)]
        public string AddressLine2 { get; set; }
        [MaxLength(50)]
        public string AddressBuildingNo { get; set; }
        [MaxLength(50)]
        public string ZIPCode { get; set; }
        public int? RegionID { get; set; }
        public int? CityID { get; set; }
        public int? CountryID { get; set; }
        [MaxLength(50)]
        public string WorkEmail { get; set; }
        [MaxLength(50)]
        public string PrivateEmail { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string CellPhone { get; set; }
        public int? GenderID { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public int? ContractPeriod { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public decimal? Salary { get; set; }
        public int? DegreeOfAssessmentID { get; set; }
        public int? NationalityID { get; set; }
        public int? EmploymentType { get; set; }
        public int? MilitaryStatusID { get; set; }
        public int? MaritalStatusID { get; set; }
        public int? ReligionID { get; set; }
        public int? JobID { get; set; }
        public int? ManagerID { get; set; }
        public int? ShiftTypeID { get; set; }
        public int? DepartmentID { get; set; }
        public string Attachment { get; set; }
        public bool? IsManager { get; set; }
        public int? CreatedBy { get; set; }
        public byte[] EmployeeImage { get; set; }
        public int? EditedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? EditOn { get; set; }
        public int? EditBy { get; set; }
        public bool? Status { get; set; }
        public bool? HiringProcDone { get; set; }
        public decimal? TotalHoursPerDayperty { get; set; }
        public int? OrgChartClass { get; set; }
        public int? BankId { get; set; }

        public string ContractType { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TimeOfMilitary { get; set; }
        public int? BranchID { get; set; }
        public int? ContractTypeId { get; set; }
        public string BankAccount { get; set; }
        [ForeignKey("Manager")]
        public int? ReportsTo { get; set; }
        public bool? IsAssignedWith { get; set; }
        //Reference Navigation Properties
        public virtual Employee Manager { get; set; }



        //Collection Navigation Properties
       
       
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
       
        public virtual ICollection<Invoice> Invoices { get; set; }
       




    }
}