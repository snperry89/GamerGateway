namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "Review_ReviewId", "dbo.Review");
            DropIndex("dbo.Game", new[] { "Review_ReviewId" });
            AddColumn("dbo.Review", "GameName", c => c.String());
            DropColumn("dbo.Game", "Review_ReviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Review_ReviewId", c => c.Int());
            DropColumn("dbo.Review", "GameName");
            CreateIndex("dbo.Game", "Review_ReviewId");
            AddForeignKey("dbo.Game", "Review_ReviewId", "dbo.Review", "ReviewId");
        }
    }
}
