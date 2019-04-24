namespace LinkedCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetReportsToAsForeginKeyInEmployees : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "ReportsTo");
            RenameColumn(table: "dbo.Employees", name: "Manager_EmployeeId", newName: "ReportsTo");
            RenameIndex(table: "dbo.Employees", name: "IX_Manager_EmployeeId", newName: "IX_ReportsTo");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_ReportsTo", newName: "IX_Manager_EmployeeId");
            RenameColumn(table: "dbo.Employees", name: "ReportsTo", newName: "Manager_EmployeeId");
            AddColumn("dbo.Employees", "ReportsTo", c => c.Int());
        }
    }
}
