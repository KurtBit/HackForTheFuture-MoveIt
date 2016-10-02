namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TournamentEvents", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TournamentEvents", "Description");
        }
    }
}
