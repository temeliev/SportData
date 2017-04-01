namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CDateTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IdentityUsers", "CDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IdentityUsers", "CDate", c => c.DateTime());
        }
    }
}
