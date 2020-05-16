namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "Password", c => c.String());
            DropColumn("dbo.Students", "Specialty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Specialty", c => c.String());
            DropColumn("dbo.Teachers", "Password");
            DropColumn("dbo.Exams", "Year");
        }
    }
}
