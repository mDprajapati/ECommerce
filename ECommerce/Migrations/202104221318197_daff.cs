namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuyProducts", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.BuyProducts", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyProducts", "CustomerID", c => c.Int(nullable: false));
            DropColumn("dbo.BuyProducts", "UserID");
        }
    }
}
