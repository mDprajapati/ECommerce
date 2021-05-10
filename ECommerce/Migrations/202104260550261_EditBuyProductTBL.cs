namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBuyProductTBL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuyProducts", "purchesedate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BuyProducts", "CardNumber");
            DropColumn("dbo.BuyProducts", "CVV");
            DropColumn("dbo.BuyProducts", "CardType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyProducts", "CardType", c => c.String());
            AddColumn("dbo.BuyProducts", "CVV", c => c.Int(nullable: false));
            AddColumn("dbo.BuyProducts", "CardNumber", c => c.Int(nullable: false));
            DropColumn("dbo.BuyProducts", "purchesedate");
        }
    }
}
