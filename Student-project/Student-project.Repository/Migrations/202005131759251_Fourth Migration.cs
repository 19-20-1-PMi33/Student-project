namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Title);
            
            AddColumn("dbo.Departments", "Faculties_Title", c => c.String(maxLength: 128));
            CreateIndex("dbo.Departments", "Faculties_Title");
            AddForeignKey("dbo.Departments", "Faculties_Title", "dbo.Faculties", "Title");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Faculties_Title", "dbo.Faculties");
            DropIndex("dbo.Departments", new[] { "Faculties_Title" });
            DropColumn("dbo.Departments", "Faculties_Title");
            DropTable("dbo.Faculties");
        }
    }
}
