namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        processed = c.Int(),
                        processedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.taskId)
                .ForeignKey("dbo.Users", t => t.createdById, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ownerId, cascadeDelete: true)
                .Index(t => t.ownerId)
                .Index(t => t.createdById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        twitter = c.String(),
                        processed = c.Int(),
                        registered = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ownerId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "createdById", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "createdById" });
            DropIndex("dbo.Tasks", new[] { "ownerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
