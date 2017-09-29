namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieModeluServiceHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Describe = c.String(nullable: false, maxLength: 255),
                        Key = c.String(),
                        StatusId = c.Int(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceHistories", "StatusId", "dbo.Status");
            DropIndex("dbo.ServiceHistories", new[] { "StatusId" });
            DropTable("dbo.ServiceHistories");
        }
    }
}
