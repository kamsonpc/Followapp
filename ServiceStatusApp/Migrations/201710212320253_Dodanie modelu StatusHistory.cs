namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniemodeluStatusHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        ChangeDate = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatusHistories", "StatusId", "dbo.Status");
            DropIndex("dbo.StatusHistories", new[] { "StatusId" });
            DropTable("dbo.StatusHistories");
        }
    }
}
