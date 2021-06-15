using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Service
{
    public class WebService : IWebService
    {
        public bool addEntity(object entity)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            if (entity is Ekipa)
            {
                if(context.Ekipe.Contains(entity as Ekipa)) { return false; }
                context.Ekipe.Add(entity as Ekipa);
                context.SaveChanges();
                return true;
            }else if (entity is Element)
            {
                if (context.Elementi.Contains(entity as Element)) { return false; }
                context.Elementi.Add(entity as Element);
                context.SaveChanges();
                return true;
            }
            else if (entity is Incident)
            {
                if (context.Incidents.Contains(entity as Incident)) { return false; }
                context.Incidents.Add(entity as Incident);
                context.SaveChanges();
                return true;
            }
            else if (entity is NalogRada)
            {
                if (context.NaloziRada.Contains(entity as NalogRada)) { return false; }
                context.NaloziRada.Add(entity as NalogRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is PlanRada)
            {
                if (context.PlanoviRada.ToList().Find(x=>x.IdPlana.Equals((entity as PlanRada).IdPlana)) != null) { return false; }
                context.PlanoviRada.Add(entity as PlanRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poruka)
            {
                if (context.Poruke.Contains(entity as Poruka)) { return false; }
                context.Poruke.Add(entity as Poruka);
                context.SaveChanges();
                return true;
            }
            else if (entity is Potrosac)
            {
                if (context.Potrosaci.Contains(entity as Potrosac)) { return false; }
                context.Potrosaci.Add(entity as Potrosac);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poziv)
            {
                if (context.Pozivi.Contains(entity as Poziv)) { return false; }
                context.Pozivi.Add(entity as Poziv);
                context.SaveChanges();
                return true;
            }
            else if (entity is Resolution)
            {
                if (context.Resolutions.Contains(entity as Resolution)) { return false; }
                context.Resolutions.Add(entity as Resolution);
                context.SaveChanges();
                return true;
            }
            else if (entity is SafetyDocument)
            {
                if (context.SafetyDocuments.Contains(entity as SafetyDocument)) { return false; }
                context.SafetyDocuments.Add(entity as SafetyDocument);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteEntity(object entity)
        {
            ApplicationDbContext context = new ApplicationDbContext();


            if (entity is Ekipa)
            {
                foreach (object item in context.PlanoviRada.ToList().FindAll(x => x.IdIncidenta.Equals((entity as Ekipa).IdEkipe)))
                {
                    deleteEntity(item);
                }
                context.Ekipe.Remove(context.Ekipe.ToList().Find(x => x.IdEkipe.Equals((entity as Ekipa).IdEkipe)));
                context.SaveChanges();
                return true;
            }
            else if (entity is Element)
            {
                context.Elementi.Remove(context.Elementi.ToList().Find(x => x.ID.Equals((entity as Element).ID)));
                context.SaveChanges();
                return true;
            }
            else if (entity is Incident)
            {
                foreach(object item in context.NaloziRada.ToList().FindAll(x=>x.IdIncidenta.Equals((entity as Incident).ID)))
                {
                    deleteEntity(item);
                }
                foreach (object item in context.PlanoviRada.ToList().FindAll(x => x.IdIncidenta.Equals((entity as Incident).ID)))
                {
                    deleteEntity(item);
                }
                context.Incidents.Remove(context.Incidents.ToList().Find(x => x.ID.Equals((entity as Incident).ID)));
                context.SaveChanges();
                return true;
            }
            else if (entity is NalogRada)
            {
                foreach (object item in context.PlanoviRada.ToList().FindAll(x => x.IdNalogaRada.Equals((entity as NalogRada).IdNaloga)))
                {
                    deleteEntity(item);
                }
                context.NaloziRada.Remove(context.NaloziRada.ToList().Find(x => x.IdNaloga.Equals((entity as NalogRada).IdNaloga)));
                context.SaveChanges();
                return true;
            }
            else if (entity is PlanRada)
            {
                context.PlanoviRada.Remove(context.PlanoviRada.ToList().Find(x => x.IdPlana.Equals((entity as PlanRada).IdPlana)));
                context.SaveChanges();
                return true;
            }
            else if (entity is Poruka)
            {
                context.Poruke.Remove(context.Poruke.ToList().Find(x => x.IdPoruke.Equals((entity as Poruka).IdPoruke)));
                context.SaveChanges();
                return true;
            }
            else if (entity is Potrosac)
            {
                foreach (object item in context.Poruke.ToList().FindAll(x => x.IdKorisnika.Equals((entity as Potrosac).Id)))
                {
                    deleteEntity(item);
                }
                context.Potrosaci.Remove(context.Potrosaci.ToList().Find(x => x.Id.Equals((entity as Potrosac).Id)));
                context.SaveChanges();
                return true;
            }
            else if (entity is Poziv)
            {
                context.Pozivi.Remove(context.Pozivi.ToList().Find(x => x.Id.Equals((entity as Poziv).Id)));
                context.SaveChanges();
                return true;
            }
            else if (entity is Resolution)
            {
                context.Resolutions.Remove(context.Resolutions.ToList().Find(x => x.IdRes.Equals((entity as Resolution).IdRes)));
                context.SaveChanges();
                return true;
            }
            else if (entity is SafetyDocument)
            {
                context.SafetyDocuments.Remove(context.SafetyDocuments.ToList().Find(x => x.Id.Equals((entity as SafetyDocument).Id)));
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<object> getEntities(TipEntiteta tip)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<object> list = new List<object>(); 

            switch (tip){
                case TipEntiteta.EKIPE:
                    foreach(object item in context.Ekipe)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.ELEMENTS:
                    foreach (object item in context.Elementi)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.INCIDENTS:
                    foreach (object item in context.Incidents)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.NALOZI:
                    foreach (object item in context.NaloziRada)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.PLANOVI:
                    foreach (object item in context.PlanoviRada)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.PORUKE:
                    foreach (object item in context.Poruke)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.POTROSACI:
                    foreach (object item in context.Potrosaci)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.POZIVI:
                    foreach (object item in context.Pozivi)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.RESOLUTIONS:
                    foreach (object item in context.Resolutions)
                    {
                        list.Add(item);
                    }
                    return list;
                case TipEntiteta.SAFETY_DOCUMENTS:
                    foreach (object item in context.SafetyDocuments)
                    {
                        list.Add(item);
                    }
                    return list;
            }
            return list;
        }

        public object getEntity(TipEntiteta tip, string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();



            switch (tip)
            {
                case TipEntiteta.EKIPE:
                    return context.Ekipe.FirstOrDefault(x => x.IdEkipe == id);
                case TipEntiteta.ELEMENTS:
                    return context.Elementi.FirstOrDefault(x => x.ID == id);
                case TipEntiteta.INCIDENTS:
                    return context.Incidents.FirstOrDefault(x => x.ID == id);
                case TipEntiteta.NALOZI:
                    return context.NaloziRada.FirstOrDefault(x => x.IdNaloga == id);
                case TipEntiteta.PLANOVI:
                    return context.PlanoviRada.FirstOrDefault(x => x.IdPlana == id);
                case TipEntiteta.PORUKE:
                    return context.Poruke.FirstOrDefault(x => x.IdPoruke == id);
                case TipEntiteta.POTROSACI:
                    return context.Potrosaci.FirstOrDefault(x => x.Id == id);
                case TipEntiteta.POZIVI:
                    return context.Pozivi.FirstOrDefault(x => x.Id == id);
                case TipEntiteta.RESOLUTIONS:
                    return context.Resolutions.FirstOrDefault(x => x.IdRes == id);
                case TipEntiteta.SAFETY_DOCUMENTS:
                    return context.SafetyDocuments.FirstOrDefault(x => x.Id == id);
            }
            return new object();
        }

        public bool updateEntity(object entity)
        {
            ApplicationDbContext context = new ApplicationDbContext();


            if (entity is Ekipa)
            {
                context.Ekipe.Remove(context.Ekipe.ToList().Find(x => x.IdEkipe.Equals((entity as Ekipa).IdEkipe)));
                context.Ekipe.Add(entity as Ekipa);
                context.SaveChanges();
                return true;
            }
            else if (entity is Element)
            {
                context.Elementi.Remove(context.Elementi.ToList().Find(x => x.ID.Equals((entity as Element).ID)));
                context.Elementi.Add(entity as Element);
                context.SaveChanges();
                return true;
            }
            else if (entity is Incident)
            {
                context.Incidents.Remove(context.Incidents.ToList().Find(x => x.ID.Equals((entity as Incident).ID)));
                context.Incidents.Add(entity as Incident);
                context.SaveChanges();
                return true;
            }
            else if (entity is NalogRada)
            {
                context.NaloziRada.Remove(context.NaloziRada.ToList().Find(x => x.IdNaloga.Equals((entity as NalogRada).IdNaloga)));
                context.NaloziRada.Add(entity as NalogRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is PlanRada)
            {
                context.PlanoviRada.Remove(context.PlanoviRada.ToList().Find(x=>x.IdPlana.Equals((entity as PlanRada).IdPlana)));
                context.PlanoviRada.Add(entity as PlanRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poruka)
            {
                context.Poruke.Remove(context.Poruke.ToList().Find(x => x.IdPoruke.Equals((entity as Poruka).IdPoruke)));
                context.Poruke.Add(entity as Poruka);
                context.SaveChanges();
                return true;
            }
            else if (entity is Potrosac)
            {
                context.Potrosaci.Remove(context.Potrosaci.ToList().Find(x => x.Id.Equals((entity as Potrosac).Id)));
                context.Potrosaci.Add(entity as Potrosac);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poziv)
            {
                context.Pozivi.Remove(context.Pozivi.ToList().Find(x => x.Id.Equals((entity as Poziv).Id)));
                context.Pozivi.Add(entity as Poziv);
                context.SaveChanges();
                return true;
            }
            else if (entity is Resolution)
            {
                context.Resolutions.Remove(context.Resolutions.ToList().Find(x => x.IdRes.Equals((entity as Resolution).IdRes)));
                context.Resolutions.Add(entity as Resolution);
                context.SaveChanges();
                return true;
            }
            else if (entity is SafetyDocument)
            {
                context.SafetyDocuments.Remove(context.SafetyDocuments.ToList().Find(x => x.Id.Equals((entity as SafetyDocument).Id)));
                context.SafetyDocuments.Add(entity as SafetyDocument);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
