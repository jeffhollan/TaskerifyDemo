namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDAteTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "processedTime", c => c.DateTime());
            AlterColumn("dbo.Users", "processedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "processedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "processedTime", c => c.DateTime(nullable: false));
        }
    }
}
