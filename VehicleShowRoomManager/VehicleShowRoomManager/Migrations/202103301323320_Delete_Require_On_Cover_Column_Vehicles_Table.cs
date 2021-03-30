namespace VehicleShowRoomManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_Require_On_Cover_Column_Vehicles_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Cover", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Cover", c => c.String(nullable: false));
        }
    }
}
