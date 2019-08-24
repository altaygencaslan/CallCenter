namespace CallCenter.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tickets", "Description", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Tickets", "TicketOwnerFullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "TicketOwnerFullName", c => c.String());
            AlterColumn("dbo.Tickets", "Description", c => c.String());
            AlterColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
