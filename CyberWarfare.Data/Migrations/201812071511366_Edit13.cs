namespace CyberWarfare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryTech = c.String(nullable: false),
                        DipRelations = c.String(nullable: false),
                        StaffAmount = c.Int(nullable: false),
                        CountryBudget = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Country");
        }
    }
}
