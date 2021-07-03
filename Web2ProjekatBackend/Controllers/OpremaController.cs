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
    public class OpremaController : ApiController
    {
        // GET: Oprema
        //Service.IWebService proxy;

        IOpremaRepository proxy;
        
        public OpremaController()
        {
            proxy = new OpremaRepository();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Oprema))]
        public IHttpActionResult Put(string id, [FromBody] Oprema ekipa)
        {
            if (ekipa.IdOprema != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.UpdateOprema(ekipa);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.GetOpremaById(id));
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Oprema))]
        public IHttpActionResult Post(Oprema oprema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.AddOprema(oprema);
            return CreatedAtRoute("DefaultApi", new { id = oprema.IdOprema }, oprema);
        }

        public IEnumerable<Oprema> Get()
        {
            return proxy.GetOprema();
        }

        public IEnumerable<Oprema> GetOprema(string incId)
        {
            List<Oprema> opr = proxy.GetOprema().ToList();
            return opr.Where(x => x.IncidentId == incId);
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Oprema))]
        public IHttpActionResult Get(string id)
        {
            Oprema ek = proxy.GetOpremaById(id);
            if (ek == null)
            {
                return NotFound();
            }
            return Ok(ek);
        }




        //[System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            Oprema oprema = proxy.GetOpremaById(id);
            
            if (oprema == null)
            {
                return NotFound();
            }

            proxy.DeleteOprema(oprema);
            return Ok();
        }
    }
}