namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Opremachange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OpremaIncidents", "Oprema_IdOprema", "dbo.Opremas");
            DropForeignKey("dbo.OpremaIncidents", "Incident_ID", "dbo.Incidents");
            DropIndex("dbo.OpremaIncidents", new[] { "Oprema_IdOprema" });
            DropIndex("dbo.OpremaIncidents", new[] { "Incident_ID" });
            AddColumn("dbo.Opremas", "IncidentId", c => c.Int(nullable: false));
            AddColumn("dbo.Opremas", "Incident_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Opremas", "Incident_ID");
            AddForeignKey("dbo.Opremas", "Incident_ID", "dbo.Incidents", "ID");
            DropTable("dbo.OpremaIncidents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OpremaIncidents",
                c => new
                    {
                        Oprema_IdOprema = c.String(nullable: false, maxLength: 128),
                        Incident_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Oprema_IdOprema, t.Incident_ID });
            
            DropForeignKey("dbo.Opremas", "Incident_ID", "dbo.Incidents");
            DropIndex("dbo.Opremas", new[] { "Incident_ID" });
            DropColumn("dbo.Opremas", "Incident_ID");
            DropColumn("dbo.Opremas", "IncidentId");
            CreateIndex("dbo.OpremaIncidents", "Incident_ID");
            CreateIndex("dbo.OpremaIncidents", "Oprema_IdOprema");
            AddForeignKey("dbo.OpremaIncidents", "Incident_ID", "dbo.Incidents", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OpremaIncidents", "Oprema_IdOprema", "dbo.Opremas", "IdOprema", cascadeDelete: true);
        }
    }
}
