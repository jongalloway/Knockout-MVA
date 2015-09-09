namespace Services_Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        DateClosed = c.DateTime(),
                        AssignedTo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Developers", t => t.AssignedTo_ID)
                .Index(t => t.AssignedTo_ID);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bugs", "AssignedTo_ID", "dbo.Developers");
            DropIndex("dbo.Bugs", new[] { "AssignedTo_ID" });
            DropTable("dbo.Developers");
            DropTable("dbo.Bugs");
        }
    }
}
