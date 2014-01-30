namespace Stopwatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "ADName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "ADName", c => c.String());
        }
    }
}
