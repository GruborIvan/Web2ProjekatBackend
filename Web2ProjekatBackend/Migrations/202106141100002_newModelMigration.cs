namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModelMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ekipe",
                c => new
                    {
                        IdEkipe = c.String(nullable: false, maxLength: 128),
                        NazivEkipe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEkipe);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Naziv = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                        ElementType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        IncidentType = c.Int(nullable: false),
                        Prioritet = c.Int(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        ETA = c.DateTime(nullable: false),
                        ATA = c.DateTime(nullable: false),
                        ETR = c.DateTime(nullable: false),
                        VrijemeRada = c.DateTime(nullable: false),
                        AffectedPeople = c.Int(nullable: false),
                        Pozivi = c.Int(nullable: false),
                        Voltage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Nalozi",
                c => new
                    {
                        IdNaloga = c.String(nullable: false, maxLength: 128),
                        NalogType = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        IdIncidenta = c.String(nullable: false, maxLength: 255),
                        Ulica = c.String(nullable: false, maxLength: 255),
                        PocetakRada = c.DateTime(nullable: false),
                        KrajRada = c.DateTime(nullable: false),
                        Svrha = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        Hitno = c.Boolean(nullable: false),
                        Kompanija = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        CreatedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdNaloga);
            
            CreateTable(
                "dbo.Planovi",
                c => new
                    {
                        IdPlana = c.String(nullable: false, maxLength: 128),
                        DocumentType = c.Int(nullable: false),
                        IdNalogaRada = c.String(nullable: false, maxLength: 255),
                        Status = c.String(nullable: false, maxLength: 255),
                        IdIncidenta = c.String(nullable: false, maxLength: 255),
                        Ulica = c.String(nullable: false, maxLength: 255),
                        PocetakRada = c.DateTime(nullable: false),
                        KrajRada = c.DateTime(nullable: false),
                        Ekipa = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        Svrha = c.String(nullable: false),
                        Detalji = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        Kompanija = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlana);
            
            CreateTable(
                "dbo.Poruke",
                c => new
                    {
                        IdPoruke = c.String(nullable: false, maxLength: 128),
                        IdKorisnika = c.String(nullable: false),
                        Sadrzaj = c.String(nullable: false),
                        Tip = c.String(nullable: false),
                        Procitana = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPoruke);
            
            CreateTable(
                "dbo.Potrosaci",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Lokacija = c.String(),
                        Prioritet = c.Int(nullable: false),
                        TelefonskiBroj = c.String(),
                        PotrosacType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pozivi",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Razlog = c.String(nullable: false, maxLength: 255),
                        Komentar = c.String(nullable: false, maxLength: 255),
                        Kvar = c.String(nullable: false, maxLength: 255),
                        UsernameKor = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        IdRes = c.String(nullable: false, maxLength: 128),
                        Cause = c.String(nullable: false),
                        SubCause = c.String(nullable: false),
                        Construction = c.String(nullable: false),
                        Material = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdRes);
            
            CreateTable(
                "dbo.SafetyDocuments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SafetyType = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        IdNalogaRada = c.String(nullable: false, maxLength: 255),
                        Ekipa = c.String(nullable: false, maxLength: 255),
                        Detalji = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SafetyDocuments");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Pozivi");
            DropTable("dbo.Potrosaci");
            DropTable("dbo.Poruke");
            DropTable("dbo.Planovi");
            DropTable("dbo.Nalozi");
            DropTable("dbo.Incidents");
            DropTable("dbo.Elements");
            DropTable("dbo.Ekipe");
        }
    }
}
