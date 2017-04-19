namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayerStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FootballTeamsPlayers", "PlayerStatusId", c => c.Int());
            CreateIndex("dbo.FootballTeamsPlayers", "PlayerStatusId");
            AddForeignKey("dbo.FootballTeamsPlayers", "PlayerStatusId", "dbo.PlayerStatuses", "Id");
            DropColumn("dbo.FootballTeamsPlayers", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FootballTeamsPlayers", "IsDeleted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.FootballTeamsPlayers", "PlayerStatusId", "dbo.PlayerStatuses");
            DropIndex("dbo.FootballTeamsPlayers", new[] { "PlayerStatusId" });
            DropColumn("dbo.FootballTeamsPlayers", "PlayerStatusId");
            DropTable("dbo.PlayerStatuses");
        }
    }
}
