namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTablenamewithsoevalustooldbuyProduttoneworders : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.OrderHistories", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderHistories", "ProductPrice", c => c.Int(nullable: false));
            DropColumn("dbo.OrderHistories", "UserID");
            DropColumn("dbo.OrderHistories", "OrderDate");
            DropTable("dbo.BuyProducts");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.OrderHistories", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderHistories", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.OrderHistories", "ProductPrice");
            DropColumn("dbo.OrderHistories", "OrderID");
            DropTable("dbo.Orders");
        }
    }
}
