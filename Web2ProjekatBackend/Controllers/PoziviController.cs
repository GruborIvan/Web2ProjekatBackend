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
    public class PoziviController : ApiController
    {

        IPoziviRepository proxy;

        public PoziviController()
        {
            proxy = new PozivRepository();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poziv))]
        public IHttpActionResult Post(Poziv poziv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.AddPoziv(poziv);
            return CreatedAtRoute("DefaultApi", new { id = poziv.Id }, poziv);
        }
        

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Poziv))]
        public IEnumerable<Poziv> Get(string incidentId)
        {
            return proxy.GetPoziviForIncident(incidentId);
        }

        public IEnumerable<Poziv> Get()
        {
            return proxy.GetPozivi();
        }
    }
}