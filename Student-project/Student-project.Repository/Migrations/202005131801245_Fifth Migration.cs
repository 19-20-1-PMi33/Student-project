namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Departments", new[] { "Faculties_Title" });
            DropColumn("dbo.Departments", "Faculty");
            RenameColumn(table: "dbo.Departments", name: "Faculties_Title", newName: "Faculty");
            AlterColumn("dbo.Departments", "Faculty", c => c.String(maxLength: 128));
            CreateIndex("dbo.Departments", "Faculty");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", new[] { "Faculty" });
            AlterColumn("dbo.Departments", "Faculty", c => c.String());
            RenameColumn(table: "dbo.Departments", name: "Faculty", newName: "Faculties_Title");
            AddColumn("dbo.Departments", "Faculty", c => c.String());
            CreateIndex("dbo.Departments", "Faculties_Title");
        }
    }
}
