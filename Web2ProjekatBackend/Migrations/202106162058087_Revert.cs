namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OpremaIncidents", "Oprema_Id", "dbo.Oprema");
            DropForeignKey("dbo.OpremaIncidents", "Incident_ID", "dbo.Incidents");
            DropIndex("dbo.OpremaIncidents", new[] { "Oprema_Id" });
            DropIndex("dbo.OpremaIncidents", new[] { "Incident_ID" });
            DropTable("dbo.Oprema");
            DropTable("dbo.OpremaIncidents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OpremaIncidents",
                c => new
                    {
                        Oprema_Id = c.Int(nullable: false),
                        Incident_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Oprema_Id, t.Incident_ID });
            
            CreateTable(
                "dbo.Oprema",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Tip = c.String(),
                        Coordinates = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OpremaIncidents", "Incident_ID");
            CreateIndex("dbo.OpremaIncidents", "Oprema_Id");
            AddForeignKey("dbo.OpremaIncidents", "Incident_ID", "dbo.Incidents", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OpremaIncidents", "Oprema_Id", "dbo.Oprema", "Id", cascadeDelete: true);
        }
    }
}
