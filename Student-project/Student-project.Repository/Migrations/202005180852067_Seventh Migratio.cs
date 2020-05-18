namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigratio : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Marks", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marks", "Date", c => c.DateTime(nullable: false));
        }
    }
}
