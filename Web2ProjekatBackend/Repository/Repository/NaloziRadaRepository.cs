using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class NaloziRadaRepository : INaloziRadaRepository
    {
        ApplicationDbContext db;

        public NaloziRadaRepository()
        {
            db = new ApplicationDbContext();
        }

        public IQueryable<NalogRada> SortByColumn(string columnName)
        {

            switch (columnName)
            {
                case "ID":
                    return db.NaloziRada.OrderBy(x => x.IdNaloga);
                case "Tip":
                    return db.NaloziRada.OrderBy(x => x.Type);
                case "CreatedTime":
                    return db.NaloziRada.OrderBy(x => x.CreatedTime);
                case "StartDate":
                    return db.NaloziRada.OrderBy(x => x.PocetakRada);
                case "EndDate":
                    return db.NaloziRada.OrderBy(x => x.KrajRada);
                default:
                    return db.NaloziRada;
            }
        }
    }
}