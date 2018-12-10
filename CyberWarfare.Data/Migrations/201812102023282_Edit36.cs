namespace CyberWarfare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit36 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attack",
                c => new
                    {
                        AttackId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        AttackName = c.String(nullable: false),
                        Success = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        AttackType = c.String(nullable: false),
                        AttackingCountry = c.String(),
                    })
                .PrimaryKey(t => t.AttackId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CountryName = c.String(nullable: false),
                        CountryTech = c.String(nullable: false),
                        DipRelations = c.String(nullable: false),
                        StaffAmount = c.Int(nullable: false),
                        CountryBudget = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.DataCollect",
                c => new
                    {
                        DataCollectItemId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        AttackId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        AttackName = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                        AttackType = c.String(nullable: false),
                        Success = c.String(nullable: false),
                        AttackingCountry = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DataCollectItemId)
                .ForeignKey("dbo.Attack", t => t.AttackId, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.AttackId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.DataCollect", "CountryId", "dbo.Country");
            DropForeignKey("dbo.DataCollect", "AttackId", "dbo.Attack");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.DataCollect", new[] { "CountryId" });
            DropIndex("dbo.DataCollect", new[] { "AttackId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.DataCollect");
            DropTable("dbo.Country");
            DropTable("dbo.Attack");
        }
    }
}
