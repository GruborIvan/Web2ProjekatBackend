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
    public class PotrosacController : ApiController
    {
        // GET: PlanoviRada
        Service.IWebService proxy;
        public PotrosacController()
        {
            proxy = new Service.WebService();
        }

        
        [ResponseType(typeof(Models.Potrosac))]
        public IHttpActionResult Put(string id, [FromBody] Potrosac potrosac)
        {
            if (potrosac.Id != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.updateEntity(potrosac);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.POTROSACI, potrosac.Id));
        }

        [ResponseType(typeof(Models.Potrosac))]
        public IHttpActionResult Post(Potrosac potrosac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(potrosac);
            return CreatedAtRoute("DefaultApi", new { id = potrosac.Id }, potrosac);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Potrosac f = context.Potrosaci.ToList().Find(x => x.Id.Equals(id));
            if (f == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(f);
            return Ok();
        }

        [ResponseType(typeof(Potrosac))]
        public IHttpActionResult Get(string id)
        {
            Potrosac f = proxy.getEntity(TipEntiteta.POTROSACI, id) as Potrosac;
            if (f == null)
            {
                return NotFound();
            }
            return Ok(f);
        }
        public IEnumerable<Potrosac> Get()
        {
            List<Potrosac> pr = new List<Potrosac>();
            foreach (object item in proxy.getEntities(TipEntiteta.POTROSACI))
            {
                pr.Add(item as Potrosac);
            }
            return pr;
        }
    }
}