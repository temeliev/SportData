namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyTypesChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FootballCompetitions", new[] { "CompetitionTypeId" });
            AlterColumn("dbo.FootballCompetitions", "CompetitionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.FootballCompetitions", "CompetitionTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FootballCompetitions", new[] { "CompetitionTypeId" });
            AlterColumn("dbo.FootballCompetitions", "CompetitionTypeId", c => c.Int());
            CreateIndex("dbo.FootballCompetitions", "CompetitionTypeId");
        }
    }
}
