namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentityContactIDNotRequired : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.IdentityUsers", new[] { "ContactId" });
            AlterColumn("dbo.IdentityUsers", "ContactId", c => c.Long());
            CreateIndex("dbo.IdentityUsers", "ContactId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.IdentityUsers", new[] { "ContactId" });
            AlterColumn("dbo.IdentityUsers", "ContactId", c => c.Long(nullable: false));
            CreateIndex("dbo.IdentityUsers", "ContactId");
        }
    }
}
