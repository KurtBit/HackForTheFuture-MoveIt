namespace MoveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserTeams",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Team_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Team_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Team_Id);
            
            AddColumn("dbo.AspNetUsers", "TeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.ApplicationUserTeams", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserTeams", new[] { "Team_Id" });
            DropIndex("dbo.ApplicationUserTeams", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "TeamId");
            DropTable("dbo.ApplicationUserTeams");
            DropTable("dbo.Teams");
        }
    }
}
