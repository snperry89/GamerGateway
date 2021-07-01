namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimaryKeyNotWorking : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Game", "Id", "GameId");
            //DropPrimaryKey("dbo.Game", new[] { "Id" });
            //DropColumn("dbo.Game", "Id");
            //AddColumn("dbo.Game", "GameId", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Game", "GameId");
        }
        
        public override void Down()
        {
        }
    }
}
