namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTroops : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Troops",
                c => new
                    {
                        TroopId = c.Int(nullable: false, identity: true),
                        TroopTypeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        TroopCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TroopId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.TroopTypes", t => t.TroopTypeId, cascadeDelete: true)
                .Index(t => t.TroopTypeId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.TroopTypes",
                c => new
                    {
                        TroopTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Attack = c.Double(nullable: false),
                        Defence = c.Double(nullable: false),
                        CreationSpeed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TroopTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Troops", "TroopTypeId", "dbo.TroopTypes");
            DropForeignKey("dbo.Troops", "CityId", "dbo.Cities");
            DropIndex("dbo.Troops", new[] { "CityId" });
            DropIndex("dbo.Troops", new[] { "TroopTypeId" });
            DropTable("dbo.TroopTypes");
            DropTable("dbo.Troops");
        }
    }
}
