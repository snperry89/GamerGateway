namespace GamerGateway.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Review", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Review", "ReviewDate");
            DropColumn("dbo.Review", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Review", "ReviewDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Review", "ModifiedUtc");
            DropColumn("dbo.Review", "CreatedUtc");
        }
    }
}
