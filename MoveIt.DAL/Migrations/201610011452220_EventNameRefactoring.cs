namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventNameRefactoring : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Events", newName: "TournamentEvents");
            RenameColumn(table: "dbo.Teams", name: "TeamEvent_Id", newName: "TournamentEvent_Id");
            RenameIndex(table: "dbo.Teams", name: "IX_TeamEvent_Id", newName: "IX_TournamentEvent_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teams", name: "IX_TournamentEvent_Id", newName: "IX_TeamEvent_Id");
            RenameColumn(table: "dbo.Teams", name: "TournamentEvent_Id", newName: "TeamEvent_Id");
            RenameTable(name: "dbo.TournamentEvents", newName: "Events");
        }
    }
}
