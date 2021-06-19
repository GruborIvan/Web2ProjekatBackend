using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Web2ProjekatBackend.Models;

namespace Web2ProjekatBackend.Controllers
{
    public class IncidentiController : ApiController
    {
        // GET: Incidenti
        Service.IWebService proxy;

        public IncidentiController()
        {
            proxy = new Service.WebService();
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
                proxy.updateEntity(incident);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.INCIDENTS, incident.ID));
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Incident))]
        public IHttpActionResult Post(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(incident);
            return CreatedAtRoute("DefaultApi", new { id = incident.ID }, incident);
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Incident i = context.Incidents.ToList().Find(x => x.ID.Equals(id));
            if (i == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(i);
            return Ok();
        }
        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Incident))]
        public IHttpActionResult Get(string id)
        {
            Incident i = proxy.getEntity(TipEntiteta.INCIDENTS, id) as Incident;
            if (i == null)
            {
                return NotFound();
            }
            return Ok(i);
        }
        public IEnumerable<Incident> Get()
        {
            List<Incident> i = new List<Incident>();
            foreach (object item in proxy.getEntities(TipEntiteta.INCIDENTS))
            {
                i.Add(item as Incident);
            }
            return i;
        }
    }
}