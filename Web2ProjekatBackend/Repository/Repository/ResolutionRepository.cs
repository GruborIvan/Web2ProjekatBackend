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

        public Resolution GetResolutionsForIncident(string incidentId)
        {
            List<Resolution> ress = db.Resolutions.Where(x => x.IncidentId == incidentId).ToList();
            if (ress.Count > 0)
            {
                return ress[0];
            }
            else
            {
                return null;
            }
        }
    }
}