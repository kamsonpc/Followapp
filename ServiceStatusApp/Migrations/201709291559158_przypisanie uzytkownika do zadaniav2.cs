namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przypisanieuzytkownikadozadaniav2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "User_Id" });
            RenameColumn(table: "dbo.Services", name: "User_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Services", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Services", "ApplicationUserId");
            AddForeignKey("dbo.Services", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Services", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Services", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Services", "ApplicationUserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Services", name: "ApplicationUserId", newName: "User_Id");
            CreateIndex("dbo.Services", "User_Id");
            AddForeignKey("dbo.Services", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
