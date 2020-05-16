namespace Student_project.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Email");
        }
    }
}
