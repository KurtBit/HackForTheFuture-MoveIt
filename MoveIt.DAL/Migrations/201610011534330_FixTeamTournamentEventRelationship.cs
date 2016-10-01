namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTeamTournamentEventRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "TournamentEvent_Id", "dbo.TournamentEvents");
            DropIndex("dbo.Teams", new[] { "TournamentEvent_Id" });
            RenameColumn(table: "dbo.Teams", name: "TournamentEvent_Id", newName: "TournamentEventId");
            AddColumn("dbo.TournamentEvents", "Name", c => c.String());
            AlterColumn("dbo.Teams", "TournamentEventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "TournamentEventId");
            AddForeignKey("dbo.Teams", "TournamentEventId", "dbo.TournamentEvents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "TournamentEventId", "dbo.TournamentEvents");
            DropIndex("dbo.Teams", new[] { "TournamentEventId" });
            AlterColumn("dbo.Teams", "TournamentEventId", c => c.Int());
            DropColumn("dbo.TournamentEvents", "Name");
            RenameColumn(table: "dbo.Teams", name: "TournamentEventId", newName: "TournamentEvent_Id");
            CreateIndex("dbo.Teams", "TournamentEvent_Id");
            AddForeignKey("dbo.Teams", "TournamentEvent_Id", "dbo.TournamentEvents", "Id");
        }
    }
}
