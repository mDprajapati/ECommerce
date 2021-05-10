namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addntal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistories", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderHistories", "OrderDate");
        }
    }
}
