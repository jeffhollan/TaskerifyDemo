namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingTaskAGain : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tasks", "createdById");
            AddForeignKey("dbo.Tasks", "createdById", "dbo.Users", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "createdById", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "createdById" });
        }
    }
}
