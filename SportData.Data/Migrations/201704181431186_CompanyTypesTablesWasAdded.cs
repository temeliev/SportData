namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyTypesTablesWasAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FootballCompetitions", "CompetitionTypeId", c => c.Int());
            CreateIndex("dbo.FootballCompetitions", "CompetitionTypeId");
            AddForeignKey("dbo.FootballCompetitions", "CompetitionTypeId", "dbo.CompetitionTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballCompetitions", "CompetitionTypeId", "dbo.CompetitionTypes");
            DropIndex("dbo.FootballCompetitions", new[] { "CompetitionTypeId" });
            DropColumn("dbo.FootballCompetitions", "CompetitionTypeId");
            DropTable("dbo.CompetitionTypes");
        }
    }
}
