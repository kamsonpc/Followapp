namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WyłączenierequiredpolaKeywmodeluservice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Key", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Key", c => c.String(nullable: false));
        }
    }
}
