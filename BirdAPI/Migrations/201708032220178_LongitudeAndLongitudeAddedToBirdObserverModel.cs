namespace BirdAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongitudeAndLongitudeAddedToBirdObserverModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BirdObservers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.BirdObservers", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BirdObservers", "Longitude");
            DropColumn("dbo.BirdObservers", "Latitude");
        }
    }
}
