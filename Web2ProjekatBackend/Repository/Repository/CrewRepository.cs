using System;
using System.Collections.Generic;
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
    }
}