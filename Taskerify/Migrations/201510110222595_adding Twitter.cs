namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTwitter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "twitter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "twitter");
        }
    }
}
