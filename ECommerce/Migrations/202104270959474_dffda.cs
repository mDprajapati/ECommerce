namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dffda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        QuantityValue = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        purchesedate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.OrderHistories", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderHistories", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrderHistories", "OrderID");
            DropColumn("dbo.OrderHistories", "ProductPrice");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductPrice = c.Int(nullable: false),
                        QuantityValue = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.OrderHistories", "ProductPrice", c => c.Int(nullable: false));
            AddColumn("dbo.OrderHistories", "OrderID", c => c.Int(nullable: false));
            DropColumn("dbo.OrderHistories", "OrderDate");
            DropColumn("dbo.OrderHistories", "UserID");
            DropTable("dbo.BuyProducts");
        }
    }
}
