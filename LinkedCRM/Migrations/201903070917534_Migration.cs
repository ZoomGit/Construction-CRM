namespace LinkedCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leads", "LeadStatus", c => c.Int());
            AlterColumn("dbo.Leads", "LeadSource", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leads", "LeadSource", c => c.Int(nullable: false));
            AlterColumn("dbo.Leads", "LeadStatus", c => c.Int(nullable: false));
        }
    }
}
