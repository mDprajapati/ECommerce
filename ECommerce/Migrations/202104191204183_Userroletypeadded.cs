namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userroletypeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
        }
    }
}
