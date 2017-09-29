namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przypisanieuzytkownikadozadania : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Services", "User_Id");
            AddForeignKey("dbo.Services", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "User_Id" });
            DropColumn("dbo.Services", "User_Id");
            DropColumn("dbo.Services", "UserId");
        }
    }
}
