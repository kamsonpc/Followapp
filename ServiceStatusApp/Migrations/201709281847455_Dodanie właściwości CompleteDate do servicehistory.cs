namespace ServiceStatusApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniewłaściwościCompleteDatedoservicehistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceHistories", "CompleteDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceHistories", "CompleteDate");
        }
    }
}
