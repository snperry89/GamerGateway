namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "OwnerId");
        }
    }
}
