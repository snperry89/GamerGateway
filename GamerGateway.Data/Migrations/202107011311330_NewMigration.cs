namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.GameId);
            
            DropTable("dbo.AccessType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccessType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Purchase", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Purchase", "GameId", "dbo.Game");
            DropIndex("dbo.Purchase", new[] { "GameId" });
            DropIndex("dbo.Purchase", new[] { "OrderId" });
            DropTable("dbo.Purchase");
            DropTable("dbo.Order");
        }
    }
}
