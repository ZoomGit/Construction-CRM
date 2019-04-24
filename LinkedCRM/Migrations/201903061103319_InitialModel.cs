namespace LinkedCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        EmployeeId = c.Int(),
                        LeadId = c.Int(),
                        ActivityDate = c.DateTime(),
                        ActivityType = c.Int(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Leads", t => t.LeadId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LeadId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(),
                        EmployeeId = c.Int(),
                        Name = c.String(),
                        Street = c.String(),
                        Apartment = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        BirthDate = c.DateTime(),
                        Email = c.String(),
                        Logo = c.String(),
                        Comments = c.String(),
                        Employees = c.Int(nullable: false),
                        Industry = c.Int(nullable: false),
                        CustomerType = c.Int(),
                        Source = c.Int(),
                        Currency = c.Int(nullable: false),
                        WebSite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.ContactId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Salutation = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(),
                        Phone = c.String(),
                        Site = c.Int(nullable: false),
                        Messenger = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Position = c.String(),
                        Street = c.String(),
                        Apartment = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        LeadId = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(),
                        EmployeeId = c.Int(),
                        Name = c.String(),
                        LeadStatus = c.Int(nullable: false),
                        LeadSource = c.Int(nullable: false),
                        SourceInfo = c.String(),
                        Currency = c.String(),
                        Opportunity = c.String(),
                    })
                .PrimaryKey(t => t.LeadId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.ContactId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EnrollNo = c.Int(),
                        HRCode = c.Int(),
                        EmployeeFirstName = c.String(maxLength: 50),
                        EmployeeLastName = c.String(maxLength: 50),
                        EmployeeArabicName = c.String(maxLength: 100),
                        NationalId = c.String(maxLength: 50),
                        PassportId = c.String(maxLength: 50),
                        AddressLine1 = c.String(maxLength: 200),
                        AddressLine2 = c.String(maxLength: 200),
                        AddressBuildingNo = c.String(maxLength: 50),
                        ZIPCode = c.String(maxLength: 50),
                        RegionID = c.Int(),
                        CityID = c.Int(),
                        CountryID = c.Int(),
                        WorkEmail = c.String(maxLength: 50),
                        PrivateEmail = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        CellPhone = c.String(maxLength: 50),
                        GenderID = c.Int(),
                        BirthDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        ConfirmationDate = c.DateTime(),
                        ContractPeriod = c.Int(),
                        ContractDate = c.DateTime(),
                        ContractEndDate = c.DateTime(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        DegreeOfAssessmentID = c.Int(),
                        NationalityID = c.Int(),
                        EmploymentType = c.Int(),
                        MilitaryStatusID = c.Int(),
                        MaritalStatusID = c.Int(),
                        ReligionID = c.Int(),
                        JobID = c.Int(),
                        ManagerID = c.Int(),
                        ShiftTypeID = c.Int(),
                        DepartmentID = c.Int(),
                        Attachment = c.String(),
                        IsManager = c.Boolean(),
                        CreatedBy = c.Int(),
                        EmployeeImage = c.Binary(),
                        EditedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        EditOn = c.DateTime(),
                        EditBy = c.Int(),
                        Status = c.Boolean(),
                        HiringProcDone = c.Boolean(),
                        TotalHoursPerDayperty = c.Decimal(precision: 18, scale: 2),
                        OrgChartClass = c.Int(),
                        BankId = c.Int(),
                        ContractType = c.String(),
                        ContractStartDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        TimeOfMilitary = c.DateTime(),
                        BranchID = c.Int(),
                        ContractTypeId = c.Int(),
                        BankAccount = c.String(),
                        ReportsTo = c.Int(),
                        IsAssignedWith = c.Boolean(),
                        Manager_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.Manager_EmployeeId)
                .Index(t => t.Manager_EmployeeId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        CusotmerId = c.Int(),
                        EmployeeId = c.Int(),
                        LeadId = c.Int(),
                        Currency = c.String(maxLength: 20),
                        Date = c.DateTime(),
                        Location = c.String(maxLength: 100),
                        Total = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Double(),
                        Notes = c.String(maxLength: 300),
                        InvoiceStatus = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CusotmerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Leads", t => t.LeadId)
                .Index(t => t.CusotmerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LeadId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Picture = c.Binary(),
                        categoryId = c.Int(),
                        MainCategoryId = c.Int(),
                        CompanyId = c.Int(),
                        UnitId = c.Int(),
                        description = c.String(),
                        sale_price = c.Double(),
                        DiscountCat1 = c.Double(),
                        DiscountCat2 = c.Double(),
                        DiscountCat3 = c.Double(),
                        DiscountCat4 = c.Double(),
                        Cost_Price = c.Double(),
                        buy_price = c.Double(),
                        ReorderLevel = c.Short(),
                        MaxReorderLevel = c.Double(),
                        StartQuantity = c.Double(),
                        StartDate = c.DateTime(),
                        QuantityBalance = c.Double(),
                        Stockable = c.Boolean(nullable: false),
                        Taxable = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        QuoteId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        CustomerId = c.Int(),
                        QuoteStatus = c.Int(),
                        currency = c.String(maxLength: 50),
                        Total = c.Decimal(precision: 18, scale: 2),
                        CreatedOn = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                        Lead_LeadId = c.Int(),
                    })
                .PrimaryKey(t => t.QuoteId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Leads", t => t.Lead_LeadId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.Lead_LeadId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        EmployeeId = c.Int(),
                        LeadId = c.Int(),
                        ScheduleDateAndTime = c.DateTime(),
                        Duration = c.DateTime(),
                        Subject = c.String(maxLength: 80),
                        Attendees = c.String(maxLength: 100),
                        Description = c.String(maxLength: 200),
                        ScheduleType = c.Int(),
                        CallType = c.Int(),
                        Location = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Leads", t => t.LeadId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LeadId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        User = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ProductInvoices",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Invoice_InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Invoice_InvoiceId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.QuoteProducts",
                c => new
                    {
                        Quote_QuoteId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quote_QuoteId, t.Product_ProductId })
                .ForeignKey("dbo.Quotes", t => t.Quote_QuoteId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Quote_QuoteId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Activities", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.Activities", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Activities", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Customers", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Quotes", "Lead_LeadId", "dbo.Leads");
            DropForeignKey("dbo.Leads", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Employees", "Manager_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.QuoteProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.QuoteProducts", "Quote_QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Quotes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Quotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ProductInvoices", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ProductInvoices", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoices", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.Invoices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "CusotmerId", "dbo.Customers");
            DropForeignKey("dbo.Leads", "ContactId", "dbo.Contacts");
            DropIndex("dbo.QuoteProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.QuoteProducts", new[] { "Quote_QuoteId" });
            DropIndex("dbo.ProductInvoices", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.ProductInvoices", new[] { "Product_ProductId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Schedules", new[] { "LeadId" });
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropIndex("dbo.Schedules", new[] { "CustomerId" });
            DropIndex("dbo.Quotes", new[] { "Lead_LeadId" });
            DropIndex("dbo.Quotes", new[] { "CustomerId" });
            DropIndex("dbo.Quotes", new[] { "EmployeeId" });
            DropIndex("dbo.Invoices", new[] { "LeadId" });
            DropIndex("dbo.Invoices", new[] { "EmployeeId" });
            DropIndex("dbo.Invoices", new[] { "CusotmerId" });
            DropIndex("dbo.Employees", new[] { "Manager_EmployeeId" });
            DropIndex("dbo.Leads", new[] { "EmployeeId" });
            DropIndex("dbo.Leads", new[] { "ContactId" });
            DropIndex("dbo.Customers", new[] { "EmployeeId" });
            DropIndex("dbo.Customers", new[] { "ContactId" });
            DropIndex("dbo.Activities", new[] { "LeadId" });
            DropIndex("dbo.Activities", new[] { "EmployeeId" });
            DropIndex("dbo.Activities", new[] { "CustomerId" });
            DropTable("dbo.QuoteProducts");
            DropTable("dbo.ProductInvoices");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Schedules");
            DropTable("dbo.Quotes");
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.Employees");
            DropTable("dbo.Leads");
            DropTable("dbo.Contacts");
            DropTable("dbo.Customers");
            DropTable("dbo.Activities");
        }
    }
}
