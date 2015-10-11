namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingTaskitemsmorenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "processed", c => c.Int());
            AlterColumn("dbo.Users", "processed", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "processed", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "processed", c => c.Int(nullable: false));
        }
    }
}
