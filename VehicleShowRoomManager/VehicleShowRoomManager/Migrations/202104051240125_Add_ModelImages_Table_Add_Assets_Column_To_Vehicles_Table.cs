namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ModelImages_Table_Add_Assets_Column_To_Vehicles_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cover = c.String(),
                        Color = c.String(),
                        VehicleModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .Index(t => t.VehicleModelId);
            
            AddColumn("dbo.Vehicles", "Assets", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelImages", "VehicleModelId", "dbo.VehicleModels");
            DropIndex("dbo.ModelImages", new[] { "VehicleModelId" });
            DropColumn("dbo.Vehicles", "Assets");
            DropTable("dbo.ModelImages");
        }
    }
}
