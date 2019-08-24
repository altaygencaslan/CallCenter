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
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        TicketOwnerId = c.Int(nullable: false),
                        TicketOwnerFullName = c.String(),
                        ResponsedUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ResponsedUserId, cascadeDelete: true)
                .Index(t => t.ResponsedUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ResponsedUserId", "dbo.Employees");
            DropIndex("dbo.Tickets", new[] { "ResponsedUserId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Employees");
        }
    }
}
