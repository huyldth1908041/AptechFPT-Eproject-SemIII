namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PayMethod_To_Bills_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "PayMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "PayMethod");
        }
    }
}
