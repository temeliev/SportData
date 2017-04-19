namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FootballTeamsPlayersChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FootballTeamPlayers", newName: "FootballTeamsPlayers");
            AddColumn("dbo.FootballTeamsPlayers", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FootballTeamsPlayers", "StartDate", c => c.DateTime());
            AlterColumn("dbo.FootballTeamsPlayers", "EndDate", c => c.DateTime());
            DropColumn("dbo.FootballTeamsPlayers", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FootballTeamsPlayers", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FootballTeamsPlayers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FootballTeamsPlayers", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.FootballTeamsPlayers", "IsDeleted");
            RenameTable(name: "dbo.FootballTeamsPlayers", newName: "FootballTeamPlayers");
        }
    }
}
