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
                        Subject = c.String(maxLength: 128),
                        Teacher = c.Int(nullable: false),
                        GroupName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Groups", t => t.GroupName)
                .ForeignKey("dbo.Subjects", t => t.Subject)
                .ForeignKey("dbo.Teachers", t => t.Teacher, cascadeDelete: true)
                .Index(t => t.Subject)
                .Index(t => t.Teacher)
                .Index(t => t.GroupName);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupName = c.String(nullable: false, maxLength: 128),
                        Department = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GroupName)
                .ForeignKey("dbo.Departments", t => t.Department)
                .Index(t => t.Department);
            
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
                        Department = c.String(maxLength: 128),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department)
                .Index(t => t.Department);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Exam = c.Int(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.Exam, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.Exam)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Group = c.String(maxLength: 128),
                        Password = c.String(),
                        Specialty = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.Group)
                .Index(t => t.Group);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Group", "dbo.Groups");
            DropForeignKey("dbo.Marks", "Exam", "dbo.Exams");
            DropForeignKey("dbo.Exams", "Teacher", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Department", "dbo.Departments");
            DropForeignKey("dbo.Exams", "Subject", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "GroupName", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Department", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Group" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.Marks", new[] { "Exam" });
            DropIndex("dbo.Teachers", new[] { "Department" });
            DropIndex("dbo.Groups", new[] { "Department" });
            DropIndex("dbo.Exams", new[] { "GroupName" });
            DropIndex("dbo.Exams", new[] { "Teacher" });
            DropIndex("dbo.Exams", new[] { "Subject" });
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Exams");
            DropTable("dbo.Departments");
        }
    }
}
