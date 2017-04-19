namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FootballTeamsChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FootballTeams", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.FootballTeams", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FootballTeams", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.FootballTeams", "IsDeleted");
        }
    }
}
