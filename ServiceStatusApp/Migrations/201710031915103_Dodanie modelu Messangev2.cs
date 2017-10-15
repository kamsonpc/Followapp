namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniemodeluMessangev2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messanges", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messanges", "Text");
        }
    }
}
