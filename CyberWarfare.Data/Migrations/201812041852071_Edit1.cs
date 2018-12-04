namespace CyberWarfare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CyberAttack", "AttackName", c => c.String(nullable: false));
            DropColumn("dbo.CyberAttack", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CyberAttack", "Name", c => c.String(nullable: false));
            DropColumn("dbo.CyberAttack", "AttackName");
        }
    }
}
