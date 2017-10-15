namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniemodeluMessange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        Client = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messanges", "ServiceId", "dbo.Services");
            DropIndex("dbo.Messanges", new[] { "ServiceId" });
            DropTable("dbo.Messanges");
        }
    }
}
