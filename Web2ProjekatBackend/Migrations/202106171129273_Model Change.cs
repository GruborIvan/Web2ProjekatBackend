namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Opremas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OpremaType = c.String(),
                        Coordinates = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        VrsteKorisnika = c.Int(nullable: false),
                        NazivProfilneSlike = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Adresa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpremaIncidents",
                c => new
                    {
                        Oprema_Id = c.Int(nullable: false),
                        Incident_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Oprema_Id, t.Incident_ID })
                .ForeignKey("dbo.Opremas", t => t.Oprema_Id, cascadeDelete: true)
                .ForeignKey("dbo.Incidents", t => t.Incident_ID, cascadeDelete: true)
                .Index(t => t.Oprema_Id)
                .Index(t => t.Incident_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpremaIncidents", "Incident_ID", "dbo.Incidents");
            DropForeignKey("dbo.OpremaIncidents", "Oprema_Id", "dbo.Opremas");
            DropIndex("dbo.OpremaIncidents", new[] { "Incident_ID" });
            DropIndex("dbo.OpremaIncidents", new[] { "Oprema_Id" });
            DropTable("dbo.OpremaIncidents");
            DropTable("dbo.UserInfo");
            DropTable("dbo.Opremas");
        }
    }
}
