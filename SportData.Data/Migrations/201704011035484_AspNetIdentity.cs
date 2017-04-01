namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserAccounts", newName: "IdentityUsers");
            CreateTable(
                "dbo.IdentityUsersClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(maxLength: 150),
                        ClaimValue = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUsersLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUsersRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityUsers", t => t.UserId)
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            AddColumn("dbo.IdentityUsers", "Email", c => c.String(maxLength: 256));
            AddColumn("dbo.IdentityUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IdentityUsers", "PasswordHash", c => c.String(maxLength: 500));
            AddColumn("dbo.IdentityUsers", "SecurityStamp", c => c.String(maxLength: 500));
            AddColumn("dbo.IdentityUsers", "PhoneNumber", c => c.String(maxLength: 50));
            AddColumn("dbo.IdentityUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IdentityUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.IdentityUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.IdentityUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.IdentityUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IdentityUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.IdentityUsers", "CDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.IdentityUsers", "UserName", unique: true, name: "UserNameIndex");
            DropColumn("dbo.IdentityUsers", "Password");
            DropColumn("dbo.IdentityUsers", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IdentityUsers", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.IdentityUsers", "Password", c => c.String(nullable: false, maxLength: 250));
            DropForeignKey("dbo.IdentityUsersRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUsersRoles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUsersLogins", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUsersClaims", "UserId", "dbo.IdentityUsers");
            DropIndex("dbo.IdentityRoles", "RoleNameIndex");
            DropIndex("dbo.IdentityUsersRoles", new[] { "RoleId" });
            DropIndex("dbo.IdentityUsersRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUsersLogins", new[] { "UserId" });
            DropIndex("dbo.IdentityUsersClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            AlterColumn("dbo.IdentityUsers", "CDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IdentityUsers", "UserName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Contacts", "CDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.IdentityUsers", "AccessFailedCount");
            DropColumn("dbo.IdentityUsers", "LockoutEnabled");
            DropColumn("dbo.IdentityUsers", "LockoutEndDateUtc");
            DropColumn("dbo.IdentityUsers", "TwoFactorEnabled");
            DropColumn("dbo.IdentityUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.IdentityUsers", "PhoneNumber");
            DropColumn("dbo.IdentityUsers", "SecurityStamp");
            DropColumn("dbo.IdentityUsers", "PasswordHash");
            DropColumn("dbo.IdentityUsers", "EmailConfirmed");
            DropColumn("dbo.IdentityUsers", "Email");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUsersRoles");
            DropTable("dbo.IdentityUsersLogins");
            DropTable("dbo.IdentityUsersClaims");
            RenameTable(name: "dbo.IdentityUsers", newName: "UserAccounts");
        }
    }
}
