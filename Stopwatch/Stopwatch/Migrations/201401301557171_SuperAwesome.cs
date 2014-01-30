namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperAwesome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Engagements", "TimeSpan", c => c.Time(nullable: false));
            AddColumn("dbo.Projects", "TimeSpan", c => c.Time(nullable: false));
            DropColumn("dbo.Engagements", "EngagementHours");
            DropColumn("dbo.Projects", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Time", c => c.Time(nullable: false));
            AddColumn("dbo.Engagements", "EngagementHours", c => c.Double(nullable: false));
            DropColumn("dbo.Projects", "TimeSpan");
            DropColumn("dbo.Engagements", "TimeSpan");
        }
    }
}
