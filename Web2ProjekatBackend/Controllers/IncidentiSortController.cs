using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;
using Web2ProjekatBackend.Repository.Repository;

namespace Web2ProjekatBackend.Controllers
{
    public class IncidentiSortController : ApiController
    {
        IIncidentRepository proxy;

        public IncidentiSortController()
        {
            proxy = new IncidentRepository();
        }

        public IQueryable<Incident> Get(string columnName = "ID")
        {
            return proxy.SortByColumn(columnName);
        }

    }
}
