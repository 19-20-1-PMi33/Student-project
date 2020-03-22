namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Faculty = c.String(),
                    })
                .PrimaryKey(t => t.Title);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Teacher = c.String(),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupName = c.String(nullable: false, maxLength: 128),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.GroupName);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Exam = c.String(),
                        StudentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Group = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Hours = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Title);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Department = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
            DropTable("dbo.Groups");
            DropTable("dbo.Exams");
            DropTable("dbo.Departments");
        }
    }
}
