namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigraton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Specialty", c => c.String());
            AlterColumn("dbo.Exams", "Subject", c => c.String(maxLength: 128));
            AlterColumn("dbo.Exams", "Teacher", c => c.Int(nullable: false));
            AlterColumn("dbo.Exams", "GroupName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Groups", "Department", c => c.String(maxLength: 128));
            AlterColumn("dbo.Marks", "Exam", c => c.Int(nullable: false));
            AlterColumn("dbo.Marks", "StudentId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Students", "Group", c => c.String(maxLength: 128));
            AlterColumn("dbo.Teachers", "Department", c => c.String(maxLength: 128));
            CreateIndex("dbo.Exams", "Subject");
            CreateIndex("dbo.Exams", "Teacher");
            CreateIndex("dbo.Exams", "GroupName");
            CreateIndex("dbo.Groups", "Department");
            CreateIndex("dbo.Teachers", "Department");
            CreateIndex("dbo.Marks", "Exam");
            CreateIndex("dbo.Marks", "StudentId");
            CreateIndex("dbo.Students", "Group");
            AddForeignKey("dbo.Groups", "Department", "dbo.Departments", "Title");
            AddForeignKey("dbo.Exams", "GroupName", "dbo.Groups", "GroupName");
            AddForeignKey("dbo.Exams", "Subject", "dbo.Subjects", "Title");
            AddForeignKey("dbo.Teachers", "Department", "dbo.Departments", "Title");
            AddForeignKey("dbo.Exams", "Teacher", "dbo.Teachers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Marks", "Exam", "dbo.Exams", "Key", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Group", "dbo.Groups", "GroupName");
            AddForeignKey("dbo.Marks", "StudentId", "dbo.Students", "ID");
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
            AlterColumn("dbo.Teachers", "Department", c => c.String());
            AlterColumn("dbo.Students", "Group", c => c.String());
            AlterColumn("dbo.Marks", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Marks", "Exam", c => c.String());
            AlterColumn("dbo.Groups", "Department", c => c.String());
            AlterColumn("dbo.Exams", "GroupName", c => c.String());
            AlterColumn("dbo.Exams", "Teacher", c => c.String());
            AlterColumn("dbo.Exams", "Subject", c => c.String());
            DropColumn("dbo.Students", "Specialty");
        }
    }
}
