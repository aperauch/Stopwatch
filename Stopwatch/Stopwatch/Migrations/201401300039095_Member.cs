namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Member : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectMembers", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.ProjectMembers", "Member_ID", "dbo.Members");
            DropIndex("dbo.ProjectMembers", new[] { "Project_ID" });
            DropIndex("dbo.ProjectMembers", new[] { "Member_ID" });
            AddColumn("dbo.Projects", "member_ID", c => c.Int());
            AddForeignKey("dbo.Projects", "member_ID", "dbo.Members", "ID");
            CreateIndex("dbo.Projects", "member_ID");
            DropTable("dbo.ProjectMembers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        Project_ID = c.Int(nullable: false),
                        Member_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ID, t.Member_ID });
            
            DropIndex("dbo.Projects", new[] { "member_ID" });
            DropForeignKey("dbo.Projects", "member_ID", "dbo.Members");
            DropColumn("dbo.Projects", "member_ID");
            CreateIndex("dbo.ProjectMembers", "Member_ID");
            CreateIndex("dbo.ProjectMembers", "Project_ID");
            AddForeignKey("dbo.ProjectMembers", "Member_ID", "dbo.Members", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectMembers", "Project_ID", "dbo.Projects", "ID", cascadeDelete: true);
        }
    }
}
