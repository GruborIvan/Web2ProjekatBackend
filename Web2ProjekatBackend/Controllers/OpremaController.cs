using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web2ProjekatBackend.Models;
using Web2ProjekatBackend.Service;

namespace Web2ProjekatBackend.Controllers
{
    public class OpremaController : ApiController
    {
        IWebService proxy;

        public OpremaController()
        {
            proxy = new WebService();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Oprema))]
        public IHttpActionResult Post(Oprema oprema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(oprema);
            return CreatedAtRoute("DefaultApi", new { id = oprema.Id }, oprema);
        }


        //[System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Oprema ek = context.Oprema.ToList().Find(x => x.Id.Equals(id));
            if (ek == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(ek);
            return Ok();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Oprema))]
        public IHttpActionResult Get(string id)
        {
            Oprema ek = proxy.getEntity(TipEntiteta.OPREMA, id) as Oprema;
            if (ek == null)
            {
                return NotFound();
            }
            return Ok(ek);
        }
        public IEnumerable<Oprema> Get()
        {
            List<Oprema> ek = new List<Oprema>();
            foreach (object item in proxy.getEntities(TipEntiteta.OPREMA))
            {
                ek.Add(item as Oprema);
            }
            return ek;
        }
    }
}
