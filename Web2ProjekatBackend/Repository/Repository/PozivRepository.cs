using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class PozivRepository : IPoziviRepository
    {
        ApplicationDbContext db;

        public PozivRepository()
        {
            db = new ApplicationDbContext();
        }

        public void AddPoziv(Poziv poziv)
        {
            db.Pozivi.Add(poziv);
            db.SaveChanges();
        }

        public IEnumerable<Poziv> GetPozivi()
        {
            return db.Pozivi;
        }

        public IEnumerable<Poziv> GetPoziviForIncident(string incidentId)
        {
            return db.Pozivi.Where(x => x.IncidentId == incidentId);
        }
    }
}