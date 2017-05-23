namespace WebAPIService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        MainGenre = c.Int(nullable: false),
                        DirectorID = c.Int(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Directors", t => t.DirectorID, cascadeDelete: true)
                .Index(t => t.DirectorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DirectorID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorID" });
            DropTable("dbo.Movies");
            DropTable("dbo.Directors");
        }
    }
}
