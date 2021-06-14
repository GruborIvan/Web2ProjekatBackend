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
                context.Ekipe.Add(entity as Ekipa);
                context.SaveChanges();
                return true;
            }else if (entity is Element)
            {
                context.Elementi.Add(entity as Element);
                context.SaveChanges();
                return true;
            }
            else if (entity is Incident)
            {
                context.Incidents.Add(entity as Incident);
                context.SaveChanges();
                return true;
            }
            else if (entity is NalogRada)
            {
                context.NaloziRada.Add(entity as NalogRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is PlanRada)
            {
                context.PlanoviRada.Add(entity as PlanRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poruka)
            {
                context.Poruke.Add(entity as Poruka);
                context.SaveChanges();
                return true;
            }
            else if (entity is Potrosac)
            {
                context.Potrosaci.Add(entity as Potrosac);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poziv)
            {
                context.Pozivi.Add(entity as Poziv);
                context.SaveChanges();
                return true;
            }
            else if (entity is Resolution)
            {
                context.Resolutions.Add(entity as Resolution);
                context.SaveChanges();
                return true;
            }
            else if (entity is SafetyDocument)
            {
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
                context.Ekipe.Remove(entity as Ekipa);
                context.SaveChanges();
                return true;
            }
            else if (entity is Element)
            {
                context.Elementi.Remove(entity as Element);
                context.SaveChanges();
                return true;
            }
            else if (entity is Incident)
            {
                context.Incidents.Remove(entity as Incident);
                context.SaveChanges();
                return true;
            }
            else if (entity is NalogRada)
            {
                context.NaloziRada.Remove(entity as NalogRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is PlanRada)
            {
                context.PlanoviRada.Remove(entity as PlanRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poruka)
            {
                context.Poruke.Remove(entity as Poruka);
                context.SaveChanges();
                return true;
            }
            else if (entity is Potrosac)
            {
                context.Potrosaci.Remove(entity as Potrosac);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poziv)
            {
                context.Pozivi.Remove(entity as Poziv);
                context.SaveChanges();
                return true;
            }
            else if (entity is Resolution)
            {
                context.Resolutions.Remove(entity as Resolution);
                context.SaveChanges();
                return true;
            }
            else if (entity is SafetyDocument)
            {
                context.SafetyDocuments.Remove(entity as SafetyDocument);
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
                context.Ekipe.Remove(context.Ekipe.FirstOrDefault(x => x.IdEkipe == (entity as Ekipa).IdEkipe));
                context.Ekipe.Add(entity as Ekipa);
                context.SaveChanges();
                return true;
            }
            else if (entity is Element)
            {
                context.Elementi.Remove(context.Elementi.FirstOrDefault(x => x.ID == (entity as Element).ID));
                context.Elementi.Add(entity as Element);
                context.SaveChanges();
                return true;
            }
            else if (entity is Incident)
            {
                context.Incidents.Remove(context.Incidents.FirstOrDefault(x => x.ID == (entity as Incident).ID));
                context.Incidents.Add(entity as Incident);
                context.SaveChanges();
                return true;
            }
            else if (entity is NalogRada)
            {
                context.NaloziRada.Remove(context.NaloziRada.FirstOrDefault(x => x.IdIncidenta == (entity as NalogRada).IdIncidenta));
                context.NaloziRada.Add(entity as NalogRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is PlanRada)
            {
                context.PlanoviRada.Remove(context.PlanoviRada.FirstOrDefault(x => x.IdIncidenta == (entity as PlanRada).IdIncidenta));
                context.PlanoviRada.Add(entity as PlanRada);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poruka)
            {
                context.Poruke.Remove(context.Poruke.FirstOrDefault(x => x.IdPoruke == (entity as Poruka).IdPoruke));
                context.Poruke.Add(entity as Poruka);
                context.SaveChanges();
                return true;
            }
            else if (entity is Potrosac)
            {
                context.Potrosaci.Remove(context.Potrosaci.FirstOrDefault(x => x.Id == (entity as Potrosac).Id));
                context.Potrosaci.Add(entity as Potrosac);
                context.SaveChanges();
                return true;
            }
            else if (entity is Poziv)
            {
                context.Pozivi.Remove(context.Pozivi.FirstOrDefault(x => x.Id == (entity as Poziv).Id));
                context.Pozivi.Add(entity as Poziv);
                context.SaveChanges();
                return true;
            }
            else if (entity is Resolution)
            {
                context.Resolutions.Remove(context.Resolutions.FirstOrDefault(x => x.IdRes == (entity as Resolution).IdRes));
                context.Resolutions.Add(entity as Resolution);
                context.SaveChanges();
                return true;
            }
            else if (entity is SafetyDocument)
            {
                context.SafetyDocuments.Remove(context.SafetyDocuments.FirstOrDefault(x => x.Id == (entity as SafetyDocument).Id));
                context.SafetyDocuments.Add(entity as SafetyDocument);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
