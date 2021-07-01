namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewDBO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        ReviewDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "GameId", "dbo.Game");
            DropIndex("dbo.Review", new[] { "GameId" });
            DropTable("dbo.Review");
        }
    }
}
