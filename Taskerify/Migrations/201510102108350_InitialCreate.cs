namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        taskId = c.Guid(nullable: false),
                        ownerId = c.Guid(nullable: false),
                        createdById = c.Guid(nullable: false),
                        title = c.String(),
                        description = c.String(),
                        dueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        User_id = c.Guid(),
                        User_id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.taskId)
                .ForeignKey("dbo.Users", t => t.User_id)
                .ForeignKey("dbo.Users", t => t.User_id1)
                .ForeignKey("dbo.Users", t => t.ownerId, cascadeDelete: true)
                .Index(t => t.ownerId)
                .Index(t => t.User_id)
                .Index(t => t.User_id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        User_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ownerId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "User_id1", "dbo.Users");
            DropForeignKey("dbo.Users", "User_id", "dbo.Users");
            DropForeignKey("dbo.Tasks", "User_id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_id" });
            DropIndex("dbo.Tasks", new[] { "User_id1" });
            DropIndex("dbo.Tasks", new[] { "User_id" });
            DropIndex("dbo.Tasks", new[] { "ownerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
