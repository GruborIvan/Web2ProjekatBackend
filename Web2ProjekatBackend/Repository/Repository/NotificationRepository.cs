using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        ApplicationDbContext db;
        public NotificationRepository()
        {
            db = new ApplicationDbContext();
        }
        public IQueryable<Poruka> GetByType(TipPoruke tip)
        {
            return db.Poruke.Where(x => x.Tip == tip);
        }

        public void ReadAll(List<string> ajdijevi)
        {
            foreach(string item in ajdijevi)
            {
                Poruka p = db.Poruke.ToList().Find(x=>x.IdPoruke == item);
                p.Procitana = true;
                db.Entry<Poruka>(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IQueryable<Poruka> GetAllUnread()
        {
            return db.Poruke.Where(x => x.Procitana == false);
        }

        public IQueryable<Poruka> GetAll()
        {
            return db.Poruke;
        }

        public void AddNotification(Poruka poruka)
        {
            db.Poruke.Add(poruka);
            db.SaveChanges();
        }
    }
}