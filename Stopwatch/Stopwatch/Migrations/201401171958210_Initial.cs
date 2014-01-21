namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ADName = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Engagements",
                c => new
                    {
                        EngagementID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        StoptTime = c.DateTime(nullable: false),
                        EngagementHours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EngagementID)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Engagements", new[] { "ProjectID" });
            DropIndex("dbo.Engagements", new[] { "MemberID" });
            DropForeignKey("dbo.Engagements", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Engagements", "MemberID", "dbo.Members");
            DropTable("dbo.Projects");
            DropTable("dbo.Engagements");
            DropTable("dbo.Members");
        }
    }
}
