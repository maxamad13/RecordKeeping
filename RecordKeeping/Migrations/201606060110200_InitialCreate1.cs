namespace RecordKeeping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AssignedToStuds", "AssignmentId");
            CreateIndex("dbo.AssignedToStuds", "StudentId");
            AddForeignKey("dbo.AssignedToStuds", "AssignmentId", "dbo.Assignments", "AssignmentId", cascadeDelete: true);
            AddForeignKey("dbo.AssignedToStuds", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedToStuds", "StudentId", "dbo.Students");
            DropForeignKey("dbo.AssignedToStuds", "AssignmentId", "dbo.Assignments");
            DropIndex("dbo.AssignedToStuds", new[] { "StudentId" });
            DropIndex("dbo.AssignedToStuds", new[] { "AssignmentId" });
        }
    }
}
