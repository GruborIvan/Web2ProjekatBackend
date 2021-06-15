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
    public class ResolutionsController : ApiController
    {
        // GET: PlanoviRada
        Service.IWebService proxy;
        public ResolutionsController()
        {
            proxy = new Service.WebService();
        }

        [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Resolution))]
        public IHttpActionResult Put(string id, [FromBody] Resolution resolution)
        {
            if (resolution.IdRes != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.updateEntity(resolution);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.getEntity(TipEntiteta.RESOLUTIONS, resolution.IdRes));
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Resolution))]
        public IHttpActionResult Post(Resolution resolution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.addEntity(resolution);
            return CreatedAtRoute("DefaultApi", new { id = resolution.IdRes }, resolution);
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Resolution f = context.Resolutions.ToList().Find(x => x.IdRes.Equals(id));
            if (f == null)
            {
                return NotFound();
            }

            proxy.deleteEntity(f);
            return Ok();
        }
        [System.Web.Http.Authorize]
        [ResponseType(typeof(Resolution))]
        public IHttpActionResult Get(string id)
        {
            Resolution f = proxy.getEntity(TipEntiteta.RESOLUTIONS, id) as Resolution;
            if (f == null)
            {
                return NotFound();
            }
            return Ok(f);
        }
        public IEnumerable<Resolution> Get()
        {
            List<Resolution> pr = new List<Resolution>();
            foreach (object item in proxy.getEntities(TipEntiteta.RESOLUTIONS))
            {
                pr.Add(item as Resolution);
            }
            return pr;
        }
    }
}