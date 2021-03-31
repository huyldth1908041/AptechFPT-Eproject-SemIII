namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFK_SaleOrder_and_Customer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Customers", new[] { "VehicleId" });
            CreateIndex("dbo.SaleOrders", "VehicleId");
            AddForeignKey("dbo.SaleOrders", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "VehicleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "VehicleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SaleOrders", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.SaleOrders", new[] { "VehicleId" });
            CreateIndex("dbo.Customers", "VehicleId");
            AddForeignKey("dbo.Customers", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
    }
}
