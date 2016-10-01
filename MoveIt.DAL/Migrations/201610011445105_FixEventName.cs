namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEventName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teams", name: "Event_Id", newName: "TeamEvent_Id");
            RenameIndex(table: "dbo.Teams", name: "IX_Event_Id", newName: "IX_TeamEvent_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teams", name: "IX_TeamEvent_Id", newName: "IX_Event_Id");
            RenameColumn(table: "dbo.Teams", name: "TeamEvent_Id", newName: "Event_Id");
        }
    }
}
