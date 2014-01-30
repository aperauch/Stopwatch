namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ADName = c.String(),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
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
                        StopTime = c.DateTime(nullable: false),
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
                        Title = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        Project_ID = c.Int(nullable: false),
                        Member_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ID, t.Member_ID })
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.Member_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProjectMembers", new[] { "Member_ID" });
            DropIndex("dbo.ProjectMembers", new[] { "Project_ID" });
            DropIndex("dbo.Engagements", new[] { "ProjectID" });
            DropIndex("dbo.Engagements", new[] { "MemberID" });
            DropForeignKey("dbo.ProjectMembers", "Member_ID", "dbo.Members");
            DropForeignKey("dbo.ProjectMembers", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.Engagements", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Engagements", "MemberID", "dbo.Members");
            DropTable("dbo.ProjectMembers");
            DropTable("dbo.Projects");
            DropTable("dbo.Engagements");
            DropTable("dbo.Members");
        }
    }
}
