namespace Div.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DivAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedByUserId = c.Int(nullable: false),
                        LastDateModified = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModifiedByUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DivUsers", t => t.CreatedByUserId)
                .ForeignKey("dbo.DivUsers", t => t.LastModifiedByUserId)
                .Index(t => t.CreatedByUserId)
                .Index(t => t.LastModifiedByUserId);
            
            CreateTable(
                "dbo.DivUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DivAssignments", "LastModifiedByUserId", "dbo.DivUsers");
            DropForeignKey("dbo.DivAssignments", "CreatedByUserId", "dbo.DivUsers");
            DropIndex("dbo.DivAssignments", new[] { "LastModifiedByUserId" });
            DropIndex("dbo.DivAssignments", new[] { "CreatedByUserId" });
            DropTable("dbo.DivUsers");
            DropTable("dbo.DivAssignments");
        }
    }
}
