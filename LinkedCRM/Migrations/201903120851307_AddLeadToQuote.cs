namespace LinkedCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeadToQuote : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Quotes", name: "Lead_LeadId", newName: "LeadId");
            RenameIndex(table: "dbo.Quotes", name: "IX_Lead_LeadId", newName: "IX_LeadId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Quotes", name: "IX_LeadId", newName: "IX_Lead_LeadId");
            RenameColumn(table: "dbo.Quotes", name: "LeadId", newName: "Lead_LeadId");
        }
    }
}
