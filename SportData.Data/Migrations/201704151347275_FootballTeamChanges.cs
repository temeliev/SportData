namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FootballTeamChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FootballTeams", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.FootballTeams", "LocationId");
            AddForeignKey("dbo.FootballTeams", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballTeams", "LocationId", "dbo.Locations");
            DropIndex("dbo.FootballTeams", new[] { "LocationId" });
            DropColumn("dbo.FootballTeams", "LocationId");
        }
    }
}
