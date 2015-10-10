namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingusertaskrelationshipthing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "User_id", "dbo.Users");
            DropForeignKey("dbo.Users", "User_id", "dbo.Users");
            DropForeignKey("dbo.Tasks", "User_id1", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_id" });
            DropIndex("dbo.Tasks", new[] { "User_id1" });
            DropIndex("dbo.Users", new[] { "User_id" });
            DropColumn("dbo.Tasks", "User_id");
            DropColumn("dbo.Tasks", "User_id1");
            DropColumn("dbo.Users", "User_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_id", c => c.Guid());
            AddColumn("dbo.Tasks", "User_id1", c => c.Guid());
            AddColumn("dbo.Tasks", "User_id", c => c.Guid());
            CreateIndex("dbo.Users", "User_id");
            CreateIndex("dbo.Tasks", "User_id1");
            CreateIndex("dbo.Tasks", "User_id");
            AddForeignKey("dbo.Tasks", "User_id1", "dbo.Users", "id");
            AddForeignKey("dbo.Users", "User_id", "dbo.Users", "id");
            AddForeignKey("dbo.Tasks", "User_id", "dbo.Users", "id");
        }
    }
}
