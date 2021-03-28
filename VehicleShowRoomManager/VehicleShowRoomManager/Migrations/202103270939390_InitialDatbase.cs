namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelNumber = c.String(nullable: false),
                        ModelName = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Descriptions = c.String(),
                        BrandId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                        VehicleModelId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.VehicleModelId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Cover = c.String(nullable: false),
                        VIN = c.String(),
                        FN = c.String(),
                        SalePrice = c.Single(nullable: false),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        Control = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        VehicleModelId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .Index(t => t.VehicleModelId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);

            CreateTable(
             "dbo.Customers",
             c => new
             {
                 Id = c.Int(nullable: false, identity: true),
                 ReceiptPrice = c.Double(nullable: false),
                 ReceivedAt = c.DateTime(nullable: false),
                 PrepaymentMoney = c.Double(nullable: false),
                 VehicleId = c.Int(nullable: false),
                 Status = c.Int(nullable: false),
                 CreatedAt = c.DateTime(nullable: false),
                 UpdatedAt = c.DateTime(nullable: false),
             })
             .PrimaryKey(t => t.Id)
             .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
             .Index(t => t.VehicleId);



        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.PurchaseOrderDetails", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.VehicleModels", "BrandId", "dbo.Brands");
            DropIndex("dbo.Customers", new[] { "VehicleId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "VehicleModelId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderId" });
            DropIndex("dbo.VehicleModels", new[] { "BrandId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Brands");
        }
    }
}
