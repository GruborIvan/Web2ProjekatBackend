using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class ResolutionRepository : IResolutionRepository
    {
        ApplicationDbContext db;

        public ResolutionRepository()
        {
            db = new ApplicationDbContext();
        }

        public void AddResolution(Resolution resolution)
        {
            db.Resolutions.Add(resolution);
            db.SaveChanges();
        }

        public IEnumerable<Resolution> GetResolutions()
        {
            return db.Resolutions;
        }

        public IQueryable<Resolution> GetResolutionsForIncident(string incidentId)
        {
            return db.Resolutions.Where(x => x.IncidentId == incidentId);
        }
    }
}