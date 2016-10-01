namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teams", "Event_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.Teams", "Event_Id");
            AddForeignKey("dbo.Teams", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Event_Id", "dbo.Events");
            DropIndex("dbo.Teams", new[] { "Event_Id" });
            DropColumn("dbo.Teams", "Event_Id");
            DropTable("dbo.Events");
        }
    }
}
