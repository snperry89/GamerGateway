namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPurchasesView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Review_ReviewId", c => c.Int());
            CreateIndex("dbo.Game", "Review_ReviewId");
            AddForeignKey("dbo.Game", "Review_ReviewId", "dbo.Review", "ReviewId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "Review_ReviewId", "dbo.Review");
            DropIndex("dbo.Game", new[] { "Review_ReviewId" });
            DropColumn("dbo.Game", "Review_ReviewId");
        }
    }
}
