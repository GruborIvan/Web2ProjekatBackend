namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resolutiony : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Resolutions", "IncidentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resolutions", "IncidentId", c => c.Int(nullable: false));
        }
    }
}
