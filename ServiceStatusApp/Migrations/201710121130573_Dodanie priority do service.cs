namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodanieprioritydoservice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Priority", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Priority");
        }
    }
}
