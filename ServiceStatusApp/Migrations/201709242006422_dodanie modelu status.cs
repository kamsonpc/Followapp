namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniemodelustatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Services", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "StatusId");
            AddForeignKey("dbo.Services", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.Services", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Status", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Services", "StatusId", "dbo.Status");
            DropIndex("dbo.Services", new[] { "StatusId" });
            DropColumn("dbo.Services", "StatusId");
            DropTable("dbo.Status");
        }
    }
}
