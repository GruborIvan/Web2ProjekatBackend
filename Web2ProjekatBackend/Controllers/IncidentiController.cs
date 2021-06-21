using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Repository.Interfaces;
using Web2ProjekatBackend.Repository.Repository;

namespace Web2ProjekatBackend.Controllers
{
    public class IncidentiController : ApiController
    {
        // GET: Incidenti
        //Service.IWebService proxy;

        IIncidentRepository proxy;

        public IncidentiController()
        {
            proxy = new IncidentRepository();
        }

        //[System.Web.Http.Authorize]
        //[ResponseType(typeof(Incident))]
        //public IHttpActionResult Get(string id)
        //{
        //    Incident i = proxy.GetIncidentById(id);
        //    if (i == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(i);
        //}

        public IEnumerable<Incident> Get()
        {
            return proxy.GetIncidenti();
        }

        public IQueryable<Incident> Get(string username)
        {
            return proxy.GetMyIncidenti(username);
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Incident))]
        public IHttpActionResult Put(string id, [FromBody] Incident incident)
        {
            if (incident.ID != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.UpdateIncident(incident);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.GetIncidentById(id));
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Incident))]
        public IHttpActionResult Post(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.AddIncident(incident);
            return CreatedAtRoute("DefaultApi", new { id = incident.ID }, incident);
        }

    }
}