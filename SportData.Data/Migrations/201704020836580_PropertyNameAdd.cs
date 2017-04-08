namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyNameAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Name", c => c.String(maxLength: 250));
            AddColumn("dbo.FootballCompetitions", "Name", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.FootballPlayers", "FirstName", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.FootballPlayers", "SecondName", c => c.String(maxLength: 250));
            AddColumn("dbo.FootballPlayers", "LastName", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.FootballTeams", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FootballTeams", "Name");
            DropColumn("dbo.FootballPlayers", "LastName");
            DropColumn("dbo.FootballPlayers", "SecondName");
            DropColumn("dbo.FootballPlayers", "FirstName");
            DropColumn("dbo.FootballCompetitions", "Name");
            DropColumn("dbo.Locations", "Name");
        }
    }
}
