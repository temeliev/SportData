namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CDateChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FootballCompetitionCultures", "CDate", c => c.DateTime());
            AlterColumn("dbo.FootballPlayerCultures", "CDate", c => c.DateTime());
            AlterColumn("dbo.FootballPlayers", "CDate", c => c.DateTime());
            AlterColumn("dbo.MatchEvents", "CDate", c => c.DateTime());
            AlterColumn("dbo.Matches", "CDate", c => c.DateTime());
            AlterColumn("dbo.FootballTeams", "CDate", c => c.DateTime());
            AlterColumn("dbo.FootballTeamCultures", "CDate", c => c.DateTime());
            AlterColumn("dbo.FootballTeamPlayers", "CDate", c => c.DateTime());
            AlterColumn("dbo.MatchStatusCultures", "CDate", c => c.DateTime());
            AlterColumn("dbo.LocationCultures", "CDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocationCultures", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MatchStatusCultures", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballTeamPlayers", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballTeamCultures", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballTeams", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Matches", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MatchEvents", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballPlayers", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballPlayerCultures", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballCompetitionCultures", "CDate", c => c.DateTime(nullable: false));
        }
    }
}
