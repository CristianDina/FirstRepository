namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TroopTypes", "Name", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TroopTypes", "Name", c => c.String());
        }
    }
}
