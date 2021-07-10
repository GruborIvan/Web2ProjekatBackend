using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class CrewRepository : ICrewRepository
    {
        ApplicationDbContext db;
        public CrewRepository()
        {
            db = new ApplicationDbContext();
        }

        public IEnumerable<Ekipa> GetAll()
        {
            return db.Ekipe;
        }

        public Ekipa GetEkipaById(int id)
        {
            return db.Ekipe.Find(id);
        }

        public void UpdateIncidentCrew(string incidentId, int crewId)
        {
            try
            {
                Incident i = db.Incidents.Find(incidentId);
                i.EkipaId = crewId;
                db.Entry<Incident>(i).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch(DBConcurrencyException e)
            {
                Trace.TraceInformation(e.Message);
            }
            
        }
    }
}