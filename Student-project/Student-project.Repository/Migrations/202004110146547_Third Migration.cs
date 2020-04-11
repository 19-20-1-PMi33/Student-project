namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
        }
    }
}
