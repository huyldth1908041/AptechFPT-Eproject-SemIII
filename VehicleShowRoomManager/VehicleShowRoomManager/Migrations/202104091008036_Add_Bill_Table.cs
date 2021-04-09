namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Bill_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayedMoney = c.Single(nullable: false),
                        SaleOrderId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SaleOrders", t => t.SaleOrderId, cascadeDelete: true)
                .Index(t => t.SaleOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "SaleOrderId", "dbo.SaleOrders");
            DropIndex("dbo.Bills", new[] { "SaleOrderId" });
            DropTable("dbo.Bills");
        }
    }
}
