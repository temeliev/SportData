namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Address = c.String(maxLength: 500),
                        CountryId = c.Int(nullable: false),
                        NameOfState = c.String(maxLength: 250),
                        NameOfTown = c.String(maxLength: 250),
                        PostalCode = c.String(maxLength: 250),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        LocationImageUrl = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.FootballCompetitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalCompetitionId = c.Int(),
                        LocationId = c.Int(nullable: false),
                        CompetitionImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.FootballCompetitions", t => t.OriginalCompetitionId)
                .Index(t => t.OriginalCompetitionId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.FootballCompetitionCultures",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 250),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompetitionId, t.Culture })
                .ForeignKey("dbo.FootballCompetitions", t => t.CompetitionId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        MatchDate = c.DateTime(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Minute = c.String(maxLength: 10, fixedLength: true),
                        CDate = c.DateTime(nullable: false),
                        FootballTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FootballTeams", t => t.FootballTeam_Id)
                .ForeignKey("dbo.FootballTeams", t => t.AwayTeamId)
                .ForeignKey("dbo.FootballCompetitions", t => t.CompetitionId)
                .ForeignKey("dbo.FootballTeams", t => t.HomeTeamId)
                .ForeignKey("dbo.Seasons", t => t.SeasonId)
                .ForeignKey("dbo.MatchStatuses", t => t.StatusId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.CompetitionId)
                .Index(t => t.SeasonId)
                .Index(t => t.StatusId)
                .Index(t => t.FootballTeam_Id);
            
            CreateTable(
                "dbo.FootballTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalTeamId = c.Int(),
                        EmblemImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FootballTeams", t => t.OriginalTeamId)
                .Index(t => t.OriginalTeamId);
            
            CreateTable(
                "dbo.FootballTeamCultures",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 250),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.Culture })
                .ForeignKey("dbo.FootballTeams", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.MatchEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchId = c.Long(nullable: false),
                        TeamId = c.Int(nullable: false),
                        EventTypeId = c.Int(nullable: false),
                        MainPlayerId = c.Int(),
                        SecondaryPlayerId = c.Int(),
                        Minute = c.String(maxLength: 10, fixedLength: true),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId)
                .ForeignKey("dbo.FootballPlayers", t => t.MainPlayerId)
                .ForeignKey("dbo.FootballPlayers", t => t.SecondaryPlayerId)
                .ForeignKey("dbo.Matches", t => t.MatchId)
                .ForeignKey("dbo.FootballTeams", t => t.TeamId)
                .Index(t => t.MatchId)
                .Index(t => t.TeamId)
                .Index(t => t.EventTypeId)
                .Index(t => t.MainPlayerId)
                .Index(t => t.SecondaryPlayerId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FootballPlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NationalityId = c.Int(nullable: false),
                        PlayerImageUrl = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.NationalityId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.FootballTeamPlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FootballPlayers", t => t.PlayerId)
                .ForeignKey("dbo.FootballTeams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchStatusCultures",
                c => new
                    {
                        MatchStatusId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 250),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.MatchStatusId, t.Culture })
                .ForeignKey("dbo.MatchStatuses", t => t.MatchStatusId)
                .Index(t => t.MatchStatusId);
            
            CreateTable(
                "dbo.LocationCultures",
                c => new
                    {
                        LocationId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 250),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.LocationId, t.Culture })
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 250),
                        SecondName = c.String(maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false, maxLength: 1, fixedLength: true),
                        AddressId = c.Long(nullable: false),
                        PhoneNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        CDate = c.DateTime(nullable: false),
                        AddressInfo_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressInfo", t => t.AddressInfo_Id)
                .Index(t => t.AddressInfo_Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        ContactId = c.Long(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.FootballPlayerCultures",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 250),
                        SecondName = c.String(maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        CDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.Culture })
                .ForeignKey("dbo.FootballPlayers", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballPlayerCultures", "PlayerId", "dbo.FootballPlayers");
            DropForeignKey("dbo.UserAccounts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "AddressInfo_Id", "dbo.AddressInfo");
            DropForeignKey("dbo.Locations", "ParentId", "dbo.Locations");
            DropForeignKey("dbo.LocationCultures", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.FootballCompetitions", "OriginalCompetitionId", "dbo.FootballCompetitions");
            DropForeignKey("dbo.Matches", "StatusId", "dbo.MatchStatuses");
            DropForeignKey("dbo.MatchStatusCultures", "MatchStatusId", "dbo.MatchStatuses");
            DropForeignKey("dbo.Matches", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.FootballTeams");
            DropForeignKey("dbo.Matches", "CompetitionId", "dbo.FootballCompetitions");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.FootballTeams");
            DropForeignKey("dbo.FootballTeams", "OriginalTeamId", "dbo.FootballTeams");
            DropForeignKey("dbo.MatchEvents", "TeamId", "dbo.FootballTeams");
            DropForeignKey("dbo.MatchEvents", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.FootballTeamPlayers", "TeamId", "dbo.FootballTeams");
            DropForeignKey("dbo.FootballTeamPlayers", "PlayerId", "dbo.FootballPlayers");
            DropForeignKey("dbo.MatchEvents", "SecondaryPlayerId", "dbo.FootballPlayers");
            DropForeignKey("dbo.FootballPlayers", "NationalityId", "dbo.Locations");
            DropForeignKey("dbo.MatchEvents", "MainPlayerId", "dbo.FootballPlayers");
            DropForeignKey("dbo.MatchEvents", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Matches", "FootballTeam_Id", "dbo.FootballTeams");
            DropForeignKey("dbo.FootballTeamCultures", "TeamId", "dbo.FootballTeams");
            DropForeignKey("dbo.FootballCompetitions", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.FootballCompetitionCultures", "CompetitionId", "dbo.FootballCompetitions");
            DropForeignKey("dbo.AddressInfo", "CountryId", "dbo.Locations");
            DropIndex("dbo.FootballPlayerCultures", new[] { "PlayerId" });
            DropIndex("dbo.UserAccounts", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "AddressInfo_Id" });
            DropIndex("dbo.LocationCultures", new[] { "LocationId" });
            DropIndex("dbo.MatchStatusCultures", new[] { "MatchStatusId" });
            DropIndex("dbo.FootballTeamPlayers", new[] { "PlayerId" });
            DropIndex("dbo.FootballTeamPlayers", new[] { "TeamId" });
            DropIndex("dbo.FootballPlayers", new[] { "NationalityId" });
            DropIndex("dbo.MatchEvents", new[] { "SecondaryPlayerId" });
            DropIndex("dbo.MatchEvents", new[] { "MainPlayerId" });
            DropIndex("dbo.MatchEvents", new[] { "EventTypeId" });
            DropIndex("dbo.MatchEvents", new[] { "TeamId" });
            DropIndex("dbo.MatchEvents", new[] { "MatchId" });
            DropIndex("dbo.FootballTeamCultures", new[] { "TeamId" });
            DropIndex("dbo.FootballTeams", new[] { "OriginalTeamId" });
            DropIndex("dbo.Matches", new[] { "FootballTeam_Id" });
            DropIndex("dbo.Matches", new[] { "StatusId" });
            DropIndex("dbo.Matches", new[] { "SeasonId" });
            DropIndex("dbo.Matches", new[] { "CompetitionId" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropIndex("dbo.FootballCompetitionCultures", new[] { "CompetitionId" });
            DropIndex("dbo.FootballCompetitions", new[] { "LocationId" });
            DropIndex("dbo.FootballCompetitions", new[] { "OriginalCompetitionId" });
            DropIndex("dbo.Locations", new[] { "ParentId" });
            DropIndex("dbo.AddressInfo", new[] { "CountryId" });
            DropTable("dbo.FootballPlayerCultures");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Contacts");
            DropTable("dbo.LocationCultures");
            DropTable("dbo.MatchStatusCultures");
            DropTable("dbo.MatchStatuses");
            DropTable("dbo.Seasons");
            DropTable("dbo.FootballTeamPlayers");
            DropTable("dbo.FootballPlayers");
            DropTable("dbo.EventTypes");
            DropTable("dbo.MatchEvents");
            DropTable("dbo.FootballTeamCultures");
            DropTable("dbo.FootballTeams");
            DropTable("dbo.Matches");
            DropTable("dbo.FootballCompetitionCultures");
            DropTable("dbo.FootballCompetitions");
            DropTable("dbo.Locations");
            DropTable("dbo.AddressInfo");
        }
    }
}
