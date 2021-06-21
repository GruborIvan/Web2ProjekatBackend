using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class OpremaRepository : IOpremaRepository
    {
        ApplicationDbContext db;

        public OpremaRepository()
        {
            db = new ApplicationDbContext();
        }

        public void AddOprema(Oprema oprema)
        {
            db.Oprema.Add(oprema);
            db.SaveChanges();
        }

        public void DeleteOprema(Oprema oprema)
        {
            db.Oprema.Remove(oprema);
            db.SaveChanges();
        }

        public IEnumerable<Oprema> GetOprema()
        {
            return db.Oprema;
        }

        public Oprema GetOpremaById(string id)
        {
            return db.Oprema.Find(id);
        }

        public void UpdateOprema(Oprema oprema)
        {
            Oprema o = db.Oprema.Find(oprema.IdOprema);
            o = oprema;
            db.SaveChanges();
        }
    }
}