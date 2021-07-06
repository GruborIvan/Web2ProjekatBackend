using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;

namespace Web2ProjekatBackend.Repository.Repository
{
    public class SafetyDocumentsRepository : ISafetyDocumentsRepository
    {
        ApplicationDbContext db;

        public SafetyDocumentsRepository()
        {
            db = new ApplicationDbContext();
        }
        public IQueryable<SafetyDocument> SortByColumn(string columnName)
        {
            switch (columnName)
            {
                case "ID":
                    return db.SafetyDocuments.OrderBy(x => x.Id);
                case "PhoneNumber":
                    return db.SafetyDocuments.OrderBy(x => x.TelefonskiBroj);
                case "DocumentType":
                    return db.SafetyDocuments.OrderBy(x => x.SafetyType);
                case "CreatedOn":
                    return db.SafetyDocuments.OrderBy(x => x.CreatedOn);
                default:
                    return db.SafetyDocuments;
            }
        }
    }
}