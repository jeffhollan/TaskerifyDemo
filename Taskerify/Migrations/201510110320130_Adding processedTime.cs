namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingprocessedTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "processed", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "processedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "processedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "processedTime");
            DropColumn("dbo.Tasks", "processedTime");
            DropColumn("dbo.Tasks", "processed");
        }
    }
}
