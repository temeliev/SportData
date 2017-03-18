namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationsFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "FootballTeam_Id", "dbo.FootballTeams");
            DropIndex("dbo.Matches", new[] { "FootballTeam_Id" });
            DropIndex("dbo.Contacts", new[] { "AddressInfo_Id" });
            DropColumn("dbo.Contacts", "AddressId");
            RenameColumn(table: "dbo.Contacts", name: "AddressInfo_Id", newName: "AddressId");
            AlterColumn("dbo.Contacts", "AddressId", c => c.Long(nullable: false));
            CreateIndex("dbo.Contacts", "AddressId");
            DropColumn("dbo.Matches", "FootballTeam_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "FootballTeam_Id", c => c.Int());
            DropIndex("dbo.Contacts", new[] { "AddressId" });
            AlterColumn("dbo.Contacts", "AddressId", c => c.Long());
            RenameColumn(table: "dbo.Contacts", name: "AddressId", newName: "AddressInfo_Id");
            AddColumn("dbo.Contacts", "AddressId", c => c.Long(nullable: false));
            CreateIndex("dbo.Contacts", "AddressInfo_Id");
            CreateIndex("dbo.Matches", "FootballTeam_Id");
            AddForeignKey("dbo.Matches", "FootballTeam_Id", "dbo.FootballTeams", "Id");
        }
    }
}
