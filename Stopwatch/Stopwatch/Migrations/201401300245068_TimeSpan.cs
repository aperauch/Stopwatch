namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeSpan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Time", c => c.Time(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Time");
        }
    }
}
