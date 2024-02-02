namespace Mostaqer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "userType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "userType");
            DropColumn("dbo.AspNetUsers", "isActive");
        }
    }
}
