using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Repository.Interfaces
{
    public interface IIncidentRepository
    {
        IQueryable<Incident> GetIncidenti();
        IQueryable<Incident> GetMyIncidenti(string username);
        Incident GetIncidentById(string id);
        void AddIncident(Incident incident);
        void UpdateIncident(Incident incident);
        IQueryable<Incident> SortByColumn (string columnName);
    }
}
