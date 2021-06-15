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
    public class PorukaController : ApiController
    {
        // GET: PlanoviRada
        Service.IWebService proxy;
        public PorukaController()
        {
            proxy = new Service.WebService();
        }

        [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poruka))]
        public IHttpActionResult Put(string id, [FromBody] Poruka poziv)
        {
            if (poziv.IdPoruke != id)
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
            return Ok(proxy.getEntity(TipEntiteta.PORUKE, poziv.IdPoruke));
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poruka))]
        public IHttpActionResult Post(Poruka poziv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(poziv);
            return CreatedAtRoute("DefaultApi", new { id = poziv.IdPoruke }, poziv);
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Poruka f = context.Poruke.ToList().Find(x => x.IdPoruke.Equals(id));
            if (f == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(f);
            return Ok();
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(Poruka))]
        public IHttpActionResult Get(string id)
        {
            Poruka f = proxy.getEntity(TipEntiteta.PORUKE, id) as Poruka;
            if (f == null)
            {
                return NotFound();
            }
            return Ok(f);
        }
        public IEnumerable<Poruka> Get()
        {
            List<Poruka> pr = new List<Poruka>();
            foreach (object item in proxy.getEntities(TipEntiteta.PORUKE))
            {
                pr.Add(item as Poruka);
            }
            return pr;
        }
    }
}