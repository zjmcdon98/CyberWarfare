namespace CyberWarfare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CyberAttack", newName: "Attack");
            AddColumn("dbo.Attack", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attack", "OwnerId");
            RenameTable(name: "dbo.Attack", newName: "CyberAttack");
        }
    }
}
