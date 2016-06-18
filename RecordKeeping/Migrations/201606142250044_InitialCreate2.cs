namespace RecordKeeping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assignments", "AssignmentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assignments", "AssignmentDate", c => c.DateTime(nullable: false));
        }
    }
}
