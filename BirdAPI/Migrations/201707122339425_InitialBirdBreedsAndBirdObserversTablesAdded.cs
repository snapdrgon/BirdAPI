namespace BirdAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialBirdBreedsAndBirdObserversTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BirdBreeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ScientificName = c.String(),
                        Range = c.String(),
                        BirdObserver_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BirdObservers", t => t.BirdObserver_ID)
                .Index(t => t.BirdObserver_ID);
            
            CreateTable(
                "dbo.BirdObservers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BirdBreedID = c.Int(nullable: false),
                        Location = c.String(),
                        NumberSpotted = c.Int(nullable: true),
                        Name = c.String(),
                        ScientificName = c.String(),
                        DateObserved = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BirdBreeds", "BirdObserver_ID", "dbo.BirdObservers");
            DropIndex("dbo.BirdBreeds", new[] { "BirdObserver_ID" });
            DropTable("dbo.BirdObservers");
            DropTable("dbo.BirdBreeds");
        }
    }
}
