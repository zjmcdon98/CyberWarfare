namespace CyberWarfare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CyberAttack", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CyberAttack", "Name");
        }
    }
}
