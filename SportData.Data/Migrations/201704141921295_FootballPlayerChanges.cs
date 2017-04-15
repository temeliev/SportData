namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FootballPlayerChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FootballPlayers", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FootballPlayers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
