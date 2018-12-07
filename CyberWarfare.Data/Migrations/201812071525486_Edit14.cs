namespace CyberWarfare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Country", "OwnerTwoId", c => c.Guid(nullable: false));
            AddColumn("dbo.Country", "CountryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Country", "CountryName");
            DropColumn("dbo.Country", "OwnerTwoId");
        }
    }
}
