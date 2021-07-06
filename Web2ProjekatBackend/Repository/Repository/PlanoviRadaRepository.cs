using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class PlanoviRadaRepository : IPlanoviRadaRepository
    {
        ApplicationDbContext db;

        public PlanoviRadaRepository()
        {
            db = new ApplicationDbContext();
        }
        public IQueryable<PlanRada> SortByColumn(string columnName)
        {

            switch (columnName)
            {
                case "ID":
                    return db.PlanoviRada.OrderBy(x => x.IdNalogaRada);
                case "TipNaloga":
                    return db.PlanoviRada.OrderBy(x => x.DocumentType);
                case "CreatedTime":
                    return db.PlanoviRada.OrderBy(x => x.CreatedOn);
                case "StartDate":
                    return db.PlanoviRada.OrderBy(x => x.PocetakRada);
                case "EndDate":
                    return db.PlanoviRada.OrderBy(x => x.KrajRada);
                default:
                    return db.PlanoviRada;
            }

        }
    }
}