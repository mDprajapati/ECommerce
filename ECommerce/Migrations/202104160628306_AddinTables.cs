namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddinTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CatagoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductImage = c.String(),
                        CatagoryID = c.Int(nullable: false),
                        QuantityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Quantities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuantityNumbers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quantities");
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
