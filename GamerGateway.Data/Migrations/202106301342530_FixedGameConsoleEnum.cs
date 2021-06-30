namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedGameConsoleEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Game", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Game", "Name", c => c.String());
        }
    }
}
