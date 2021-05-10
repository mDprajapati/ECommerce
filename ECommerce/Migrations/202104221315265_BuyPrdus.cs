namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyPrdus : DbMigration
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
                        CustomerID = c.Int(nullable: false),
                        CardNumber = c.Int(nullable: false),
                        CVV = c.Int(nullable: false),
                        CardType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuyProducts");
        }
    }
}
