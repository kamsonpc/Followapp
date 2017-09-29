namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przypisanieuzytkownikadozadaniav3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Services", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Services", "ApplicationUserId");
            AddForeignKey("dbo.Services", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Services", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Services", "ApplicationUserId");
            AddForeignKey("dbo.Services", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
