namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PozivAssign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pozivi", "IncidentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pozivi", "IncidentId");
        }
    }
}
