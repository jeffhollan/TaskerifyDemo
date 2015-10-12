namespace Taskerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "dueDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "dueDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
