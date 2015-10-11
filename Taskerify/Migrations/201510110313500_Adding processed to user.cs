namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingprocessedtouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "processed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "processed");
        }
    }
}
