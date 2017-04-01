namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CultureEntityWasChanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FootballCompetitionCultures");
            DropPrimaryKey("dbo.FootballTeamCultures");
            DropPrimaryKey("dbo.MatchStatusCultures");
            DropPrimaryKey("dbo.LocationCultures");
            DropPrimaryKey("dbo.FootballPlayerCultures");
            CreateTable(
                "dbo.CultureDescription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ShowText = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FootballCompetitionCultures", "CultureId", c => c.Int(nullable: false));
            AddColumn("dbo.FootballTeamCultures", "CultureId", c => c.Int(nullable: false));
            AddColumn("dbo.MatchStatusCultures", "CultureId", c => c.Int(nullable: false));
            AddColumn("dbo.LocationCultures", "CultureId", c => c.Int(nullable: false));
            AddColumn("dbo.FootballPlayerCultures", "CultureId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FootballCompetitionCultures", new[] { "CompetitionId", "CultureId" });
            AddPrimaryKey("dbo.FootballTeamCultures", new[] { "TeamId", "CultureId" });
            AddPrimaryKey("dbo.MatchStatusCultures", new[] { "MatchStatusId", "CultureId" });
            AddPrimaryKey("dbo.LocationCultures", new[] { "LocationId", "CultureId" });
            AddPrimaryKey("dbo.FootballPlayerCultures", new[] { "PlayerId", "CultureId" });
            CreateIndex("dbo.FootballCompetitionCultures", "CultureId");
            CreateIndex("dbo.FootballPlayerCultures", "CultureId");
            CreateIndex("dbo.FootballTeamCultures", "CultureId");
            CreateIndex("dbo.MatchStatusCultures", "CultureId");
            CreateIndex("dbo.LocationCultures", "CultureId");
            AddForeignKey("dbo.FootballCompetitionCultures", "CultureId", "dbo.CultureDescription", "Id");
            AddForeignKey("dbo.FootballPlayerCultures", "CultureId", "dbo.CultureDescription", "Id");
            AddForeignKey("dbo.FootballTeamCultures", "CultureId", "dbo.CultureDescription", "Id");
            AddForeignKey("dbo.MatchStatusCultures", "CultureId", "dbo.CultureDescription", "Id");
            AddForeignKey("dbo.LocationCultures", "CultureId", "dbo.CultureDescription", "Id");
            DropColumn("dbo.FootballCompetitionCultures", "Culture");
            DropColumn("dbo.FootballTeamCultures", "Culture");
            DropColumn("dbo.MatchStatusCultures", "Culture");
            DropColumn("dbo.LocationCultures", "Culture");
            DropColumn("dbo.FootballPlayerCultures", "Culture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FootballPlayerCultures", "Culture", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.LocationCultures", "Culture", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.MatchStatusCultures", "Culture", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FootballTeamCultures", "Culture", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.FootballCompetitionCultures", "Culture", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.LocationCultures", "CultureId", "dbo.CultureDescription");
            DropForeignKey("dbo.MatchStatusCultures", "CultureId", "dbo.CultureDescription");
            DropForeignKey("dbo.FootballTeamCultures", "CultureId", "dbo.CultureDescription");
            DropForeignKey("dbo.FootballPlayerCultures", "CultureId", "dbo.CultureDescription");
            DropForeignKey("dbo.FootballCompetitionCultures", "CultureId", "dbo.CultureDescription");
            DropIndex("dbo.LocationCultures", new[] { "CultureId" });
            DropIndex("dbo.MatchStatusCultures", new[] { "CultureId" });
            DropIndex("dbo.FootballTeamCultures", new[] { "CultureId" });
            DropIndex("dbo.FootballPlayerCultures", new[] { "CultureId" });
            DropIndex("dbo.FootballCompetitionCultures", new[] { "CultureId" });
            DropPrimaryKey("dbo.FootballPlayerCultures");
            DropPrimaryKey("dbo.LocationCultures");
            DropPrimaryKey("dbo.MatchStatusCultures");
            DropPrimaryKey("dbo.FootballTeamCultures");
            DropPrimaryKey("dbo.FootballCompetitionCultures");
            DropColumn("dbo.FootballPlayerCultures", "CultureId");
            DropColumn("dbo.LocationCultures", "CultureId");
            DropColumn("dbo.MatchStatusCultures", "CultureId");
            DropColumn("dbo.FootballTeamCultures", "CultureId");
            DropColumn("dbo.FootballCompetitionCultures", "CultureId");
            DropTable("dbo.CultureDescription");
            AddPrimaryKey("dbo.FootballPlayerCultures", new[] { "PlayerId", "Culture" });
            AddPrimaryKey("dbo.LocationCultures", new[] { "LocationId", "Culture" });
            AddPrimaryKey("dbo.MatchStatusCultures", new[] { "MatchStatusId", "Culture" });
            AddPrimaryKey("dbo.FootballTeamCultures", new[] { "TeamId", "Culture" });
            AddPrimaryKey("dbo.FootballCompetitionCultures", new[] { "CompetitionId", "Culture" });
        }
    }
}
