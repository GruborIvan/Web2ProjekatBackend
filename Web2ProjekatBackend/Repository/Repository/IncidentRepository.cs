using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class IncidentRepository : IIncidentRepository
    {
        ApplicationDbContext db;

        public IncidentRepository()
        {
            db = new ApplicationDbContext();
        }

        public void AddIncident(Incident incident)
        {
            db.Incidents.Add(incident);
            db.SaveChanges();
        }

        public Incident GetIncidentById(string id)
        {
            return db.Incidents.Find(id);
        }

        public IQueryable<Incident> GetIncidenti()
        {
           return db.Incidents;
        }

        public IQueryable<Incident> GetMyIncidenti(string username)
        {
            return db.Incidents.Where(x => x.IdKorisnika == username);
        }

        public IQueryable<Incident> SortByColumn(string columnName)
        {
            
            switch (columnName)
            {
                case "ID":
                    return db.Incidents.OrderBy(x => x.ID);
                case "StartDate":
                    return db.Incidents.OrderBy(x => x.VremeIncidenta);
                case "Voltage":
                    return db.Incidents.OrderBy(x => x.Voltage);
                case "IncidentType":
                    return db.Incidents.OrderBy(x => x.IncidentType);
                case "AffectedPeople":
                    return db.Incidents.OrderBy(x => x.AffectedPeople);
                default:
                    return db.Incidents;
            }
        }

        public void UpdateIncident(Incident incident)
        {
            db.Entry<Incident>(incident).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}