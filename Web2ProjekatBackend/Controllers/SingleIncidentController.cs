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
    public class SingleIncidentController : ApiController
    {
        IIncidentRepository _repo;

        public SingleIncidentController()
        {
            _repo = new IncidentRepository();
        }

        public IHttpActionResult Get(string incidentId)
        {
            Incident inc = _repo.GetIncidentById(incidentId);
            if (inc == null)
            {
                return NotFound();
            }
            return Ok(inc);
        }
    }
}
