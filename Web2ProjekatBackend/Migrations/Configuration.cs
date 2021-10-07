namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Web2ProjekatBackend.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Web2ProjekatBackend.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Web2ProjekatBackend.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Ekipe.AddOrUpdate(
                new Ekipa() { Id = 1, NazivEkipe = "Oracle" },
                new Ekipa() { Id = 1, NazivEkipe = "Savages" },
                new Ekipa() { Id = 1, NazivEkipe = "Workers" },
                new Ekipa() { Id = 1, NazivEkipe = "Interventors" },
                new Ekipa() { Id = 1, NazivEkipe = "The chosen ones" }
            );

            context.NaloziRada.AddOrUpdate(

                new NalogRada()
                {
                    IdNaloga = "NL939",
                    Beleske = "Empty",
                    CreatedBy = "ivan@app.com",
                    CreatedTime = DateTime.Now,
                    Hitno = false,
                    Kompanija = "CSS d.o.o.",
                    KrajRada = DateTime.Now.AddDays(-1),
                    Status = "NaN",
                    Svrha = "Bez ikakve",
                    PocetakRada = DateTime.Now,
                    TelefonskiBroj = "060/3849281",
                    Type = TipRada.NEPLANIRANI_RAD,
                    Ulica = "Gogoljeva 11",
                    IdIncidenta = "INC_177189"
                },
                new NalogRada()
                {
                    IdNaloga = "NL940",
                    Beleske = "Something strange",
                    CreatedBy = "test@app.com",
                    CreatedTime = DateTime.Now.AddHours(6534),
                    Hitno = true,
                    Kompanija = "Bander d.o.o.",
                    KrajRada = DateTime.Now.AddDays(7),
                    Status = "NaN",
                    Svrha = "Bez bey",
                    PocetakRada = DateTime.Now,
                    TelefonskiBroj = "060/43214555",
                    Type = TipRada.PLANIRANI_RAD,
                    Ulica = "Gogoljeva 66",
                    IdIncidenta = "INC_631072"
                },
                new NalogRada()
                {
                    IdNaloga = "NL941",
                    Beleske = "Guid just",
                    CreatedBy = "clan@app.com",
                    CreatedTime = DateTime.Now,
                    Hitno = false,
                    Kompanija = "CSS d.o.o.",
                    KrajRada = DateTime.Now.AddDays(-1),
                    Status = "NaN",
                    Svrha = "Bez ikakve",
                    PocetakRada = DateTime.Now,
                    TelefonskiBroj = "060/3849281",
                    Type = TipRada.NEPLANIRANI_RAD,
                    Ulica = "Gogoljeva 11",
                    IdIncidenta = "INC_656711"
                }
            );

            context.SafetyDocuments.AddOrUpdate(
                new SafetyDocument()
                {
                    Id = "SFT1222",
                    Beleske = "Njema",
                    CreatedBy = "clan@app.com",
                    CreatedOn = DateTime.Now,
                    Detalji = "Cudna prica",
                    Ekipa = "Interventors",
                    Status = "Impeded",
                    IdPlanRada = "39932",
                    TelefonskiBroj = "3209324",
                    Type = TipRada.NEPLANIRANI_RAD
                },
                new SafetyDocument()
                {
                    Id = "SFT1223",
                    Beleske = "Njema",
                    CreatedBy = "test@app.com",
                    CreatedOn = DateTime.Now.AddHours(434),
                    Detalji = "No more than this.",
                    Ekipa = "The chosen ones",
                    Status = "Impeded",
                    IdPlanRada = "07645676",
                    TelefonskiBroj = "3209324",
                    Type = TipRada.NEPLANIRANI_RAD
                },
                new SafetyDocument()
                {
                    Id = "SFT1224",
                    Beleske = "Njema",
                    CreatedBy = "ivan@app.com",
                    CreatedOn = DateTime.Now,
                    Detalji = "Just oracle stuff.",
                    Ekipa = "Interventors",
                    Status = "Impeded",
                    IdPlanRada = "58954",
                    TelefonskiBroj = "3811135624",
                    Type = TipRada.PLANIRANI_RAD
                }
            );

            context.PlanoviRada.AddOrUpdate(
                new PlanRada()
                {
                    IdPlana = "PLR3399",
                    Beleske = "Plan je da se radi.",
                    CreatedBy = "ivan@app.com",
                    CreatedOn = DateTime.Now.AddHours(-32),
                    Detalji = "Detailsssy",
                    Ekipa = "Interventors",
                    IdIncidenta = "INC_631072",
                    IdNalogaRada = "NL940",
                    Kompanija = "Company doo",
                    KrajRada = DateTime.Now,
                    PocetakRada = DateTime.Now.AddHours(33),
                    Status = "Active",
                    Svrha = "Nema je",
                    TelefonskiBroj = "+3819649684",
                    Type = TipRada.NEPLANIRANI_RAD,
                    Ulica = "Strazilovska 3"

                },
                new PlanRada()
                {
                    IdPlana = "PLR3400",
                    Beleske = "Plain is to go.",
                    CreatedBy = "test@app.com",
                    CreatedOn = DateTime.Now.AddHours(-35),
                    Detalji = "Nice details",
                    Ekipa = "Interventors",
                    IdIncidenta = "INC_656711",
                    IdNalogaRada = "NL940",
                    Kompanija = "Company doo",
                    KrajRada = DateTime.Now,
                    PocetakRada = DateTime.Now.AddHours(33),
                    Status = "Active",
                    Svrha = "Nema je",
                    TelefonskiBroj = "+3819649684",
                    Type = TipRada.PLANIRANI_RAD,
                    Ulica = "Strazilovska 3"

                },
                new PlanRada()
                {
                    IdPlana = "PLR32133",
                    Beleske = "Plan je da se radi.",
                    CreatedBy = "ivan@app.com",
                    CreatedOn = DateTime.Now.AddHours(-32),
                    Detalji = "Detailsssy",
                    Ekipa = "Interventors",
                    IdIncidenta = "INC_177189",
                    IdNalogaRada = "NL940",
                    Kompanija = "Company doo",
                    KrajRada = DateTime.Now,
                    PocetakRada = DateTime.Now.AddHours(33),
                    Status = "Active",
                    Svrha = "Nema je",
                    TelefonskiBroj = "+3819654666",
                    Type = TipRada.PLANIRANI_RAD,
                    Ulica = "Sime Matavulja 3"

                }
            );

        }
    }
}
