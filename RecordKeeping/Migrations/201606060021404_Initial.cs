namespace RecordKeeping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedToStuds",
                c => new
                    {
                        AssignedToStudId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AssignedToStudId);
            
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        AssignmentName = c.String(),
                    })
                .PrimaryKey(t => t.AssignmentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assignments");
            DropTable("dbo.AssignedToStuds");
        }
    }
}
