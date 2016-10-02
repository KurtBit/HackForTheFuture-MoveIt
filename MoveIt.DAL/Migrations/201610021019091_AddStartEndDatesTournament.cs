namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartEndDatesTournament : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TournamentEvents", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TournamentEvents", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TournamentEvents", "EndDate");
            DropColumn("dbo.TournamentEvents", "StartDate");
        }
    }
}
