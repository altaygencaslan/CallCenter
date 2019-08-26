namespace CallCenter.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        Bonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        TicketOwnerId = c.Int(nullable: false),
                        ResponsedUserId = c.Int(),
                        Bonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ResponsedUserId)
                .ForeignKey("dbo.Employees", t => t.TicketOwnerId)
                .Index(t => t.TicketOwnerId)
                .Index(t => t.ResponsedUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketOwnerId", "dbo.Employees");
            DropForeignKey("dbo.Tickets", "ResponsedUserId", "dbo.Employees");
            DropIndex("dbo.Tickets", new[] { "ResponsedUserId" });
            DropIndex("dbo.Tickets", new[] { "TicketOwnerId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Employees");
        }
    }
}
