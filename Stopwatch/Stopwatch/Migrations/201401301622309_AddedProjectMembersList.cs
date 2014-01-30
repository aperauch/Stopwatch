namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectMembersList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "member_ID", "dbo.Members");
            DropIndex("dbo.Projects", new[] { "member_ID" });
            AddColumn("dbo.Members", "Project_ID", c => c.Int());
            AddColumn("dbo.Projects", "Owner_ID", c => c.Int());
            AlterColumn("dbo.Projects", "Member_ID", c => c.Int());
            AddForeignKey("dbo.Members", "Project_ID", "dbo.Projects", "ID");
            AddForeignKey("dbo.Projects", "Owner_ID", "dbo.Members", "ID");
            AddForeignKey("dbo.Projects", "Member_ID", "dbo.Members", "ID");
            CreateIndex("dbo.Members", "Project_ID");
            CreateIndex("dbo.Projects", "Owner_ID");
            CreateIndex("dbo.Projects", "Member_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "Member_ID" });
            DropIndex("dbo.Projects", new[] { "Owner_ID" });
            DropIndex("dbo.Members", new[] { "Project_ID" });
            DropForeignKey("dbo.Projects", "Member_ID", "dbo.Members");
            DropForeignKey("dbo.Projects", "Owner_ID", "dbo.Members");
            DropForeignKey("dbo.Members", "Project_ID", "dbo.Projects");
            AlterColumn("dbo.Projects", "member_ID", c => c.Int());
            DropColumn("dbo.Projects", "Owner_ID");
            DropColumn("dbo.Members", "Project_ID");
            CreateIndex("dbo.Projects", "member_ID");
            AddForeignKey("dbo.Projects", "member_ID", "dbo.Members", "ID");
        }
    }
}
