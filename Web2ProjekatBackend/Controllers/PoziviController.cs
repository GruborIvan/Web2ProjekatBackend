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
    public class PoziviController : ApiController
    {
        // GET: PlanoviRada
        Service.IWebService proxy;
        public PoziviController()
        {
            proxy = new Service.WebService();
        }

        [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poziv))]
        public IHttpActionResult Put(string id, [FromBody] Poziv poziv)
        {
            if (poziv.Id != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.updateEntity(poziv);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.POZIVI, poziv.Id));
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poziv))]
        public IHttpActionResult Post(Poziv poziv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(poziv);
            return CreatedAtRoute("DefaultApi", new { id = poziv.Id }, poziv);
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Poziv f = context.Pozivi.ToList().Find(x => x.Id.Equals(id));
            if (f == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(f);
            return Ok();
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(Poziv))]
        public IHttpActionResult Get(string id)
        {
            Poziv f = proxy.getEntity(TipEntiteta.POZIVI, id) as Poziv;
            if (f == null)
            {
                return NotFound();
            }
            return Ok(f);
        }
        public IEnumerable<Poziv> Get()
        {
            List<Poziv> pr = new List<Poziv>();
            foreach (object item in proxy.getEntities(TipEntiteta.POZIVI))
            {
                pr.Add(item as Poziv);
            }
            return pr;
        }
    }
}