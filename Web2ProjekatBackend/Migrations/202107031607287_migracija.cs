namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija : DbMigration
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
                        VremeIncidenta = c.DateTime(nullable: false),
                        VremeRada = c.DateTime(nullable: false),
                        AffectedPeople = c.Int(nullable: false),
                        Pozivi = c.Int(nullable: false),
                        Voltage = c.Int(nullable: false),
                        IdKorisnika = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Opremas",
                c => new
                    {
                        IdOprema = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        OpremaType = c.String(nullable: false, maxLength: 255),
                        Coordinates = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        IncidentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdOprema)
                .ForeignKey("dbo.Incidents", t => t.IncidentId)
                .Index(t => t.IncidentId);
            
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
                        Timestamp = c.DateTime(nullable: false),
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
                        IdEkipe = c.String(),
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
                        IncidentId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cause = c.String(nullable: false),
                        SubCause = c.String(nullable: false),
                        Construction = c.String(nullable: false),
                        Material = c.String(nullable: false),
                        IncidentId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SafetyDocuments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SafetyType = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        IdPlanRada = c.String(nullable: false, maxLength: 255),
                        Ekipa = c.String(nullable: false, maxLength: 255),
                        Detalji = c.String(nullable: false, maxLength: 255),
                        Beleske = c.String(nullable: false, maxLength: 255),
                        TelefonskiBroj = c.String(nullable: false, maxLength: 255),
                        CreatedOn = c.DateTime(nullable: false),
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
                        IsAdminApproved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Opremas", "IncidentId", "dbo.Incidents");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Opremas", new[] { "IncidentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserInfo");
            DropTable("dbo.SafetyDocuments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Pozivi");
            DropTable("dbo.Potrosaci");
            DropTable("dbo.Poruke");
            DropTable("dbo.Planovi");
            DropTable("dbo.Nalozi");
            DropTable("dbo.Opremas");
            DropTable("dbo.Incidents");
            DropTable("dbo.Elements");
            DropTable("dbo.Ekipe");
        }
    }
}
