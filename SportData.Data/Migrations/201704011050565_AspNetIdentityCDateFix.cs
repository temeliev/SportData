namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentityCDateFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "CDate", c => c.DateTime());
            AlterColumn("dbo.IdentityUsers", "CDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IdentityUsers", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "CDate", c => c.DateTime(nullable: false));
        }
    }
}
