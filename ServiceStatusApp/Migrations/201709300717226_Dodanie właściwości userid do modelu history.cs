namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodaniewłaściwościuseriddomodeluhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceHistories", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ServiceHistories", "ApplicationUserId");
            AddForeignKey("dbo.ServiceHistories", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceHistories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ServiceHistories", new[] { "ApplicationUserId" });
            DropColumn("dbo.ServiceHistories", "ApplicationUserId");
        }
    }
}
