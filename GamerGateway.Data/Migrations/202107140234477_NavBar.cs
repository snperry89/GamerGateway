namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavBar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Game", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
