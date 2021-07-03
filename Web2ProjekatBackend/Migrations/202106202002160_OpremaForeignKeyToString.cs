namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpremaForeignKeyToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Opremas", new[] { "Incident_ID" });
            DropColumn("dbo.Opremas", "IncidentId");
            RenameColumn(table: "dbo.Opremas", name: "Incident_ID", newName: "IncidentId");
            AlterColumn("dbo.Opremas", "IncidentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Opremas", "IncidentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Opremas", new[] { "IncidentId" });
            AlterColumn("dbo.Opremas", "IncidentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Opremas", name: "IncidentId", newName: "Incident_ID");
            AddColumn("dbo.Opremas", "IncidentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Opremas", "Incident_ID");
        }
    }
}
