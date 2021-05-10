namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpricedetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductPrice");
        }
    }
}
