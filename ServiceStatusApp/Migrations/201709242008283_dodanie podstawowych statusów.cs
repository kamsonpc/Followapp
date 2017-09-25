namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniepodstawowychstatusów : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status(Name) VALUES('Nieukończone')");
            Sql("INSERT INTO Status(Name) VALUES('Ukończone')");
        }
        
        public override void Down()
        {
        }
    }
}
