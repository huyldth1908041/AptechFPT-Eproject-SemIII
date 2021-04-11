namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Bill_Image_To_Bills_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "BillImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "BillImage");
        }
    }
}
