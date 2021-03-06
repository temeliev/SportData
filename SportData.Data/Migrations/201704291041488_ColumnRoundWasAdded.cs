namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnRoundWasAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "Round", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "Round");
        }
    }
}
