namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resolutiony2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resolutions", "IncidentId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resolutions", "IncidentId");
        }
    }
}
