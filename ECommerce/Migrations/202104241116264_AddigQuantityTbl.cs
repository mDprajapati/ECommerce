namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddigQuantityTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistories", "ProductQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderHistories", "ProductQuantity");
        }
    }
}
