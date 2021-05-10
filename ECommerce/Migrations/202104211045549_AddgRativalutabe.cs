namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddgRativalutabe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "RatingNumber", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "RatingNumber");
        }
    }
}
